using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerReset : MonoBehaviour
{
    public Vector2 posRevive;
    PlayerStatus player;

    public float taxaPerda, taxaGanho;

    private PlayerMovimento movim;
    private PlayerArco arco;

    bool estaMorto = false;

    private SpriteRenderer rend;

    public Color Cor_dano;
    //public Color corvermelho;
    public Color corazul;
    public Color corverde;

    GameObject ultimoCheckPoint = null;

    [SerializeField] float delayRevive = 1.5f;

    

    
    // Start is called before the first frame update.
    void Start()
    {
        player = GetComponent<PlayerStatus>();
        posRevive = transform.position;
        player.vidaAtual = player.vidaMaxima;

        rend = GetComponent<SpriteRenderer>();
        rend.color = rend.color;

        movim = GetComponent<PlayerMovimento>();
        arco = GetComponentInChildren<PlayerArco>();
    }

    // Update is called once per frame
    void Update()
    {
        // conferindo se o personagem morreu, caso sim, retornar a posição inicial.
//        if(player.vidaAtual > 0 && isDead == false){
//           
//        } 

        if ( player.vidaAtual <= 0 && !estaMorto)
        {
            estaMorto = true;
            StartCoroutine(SequenciaMorte());
            //Debug.Log(vidaAtual);
        }

        // se a vida não está cheia...
        if (player.vidaAtual<player.vidaMaxima && player.vidaAtual != player.vidaMaxima){
            // e Player está no chão, regenerar
            if(gameObject.GetComponent<PlayerMovimento>().grounded) {
                GanharVida();
            }
        }
        // para não ultrapassar a vida máxima
        if (player.vidaAtual>player.vidaMaxima){
            player.vidaAtual = player.vidaMaxima;
        }

        //variar a cor do personagem, conforme a vida atual dele, para indicar a situação da vida do personagem ao jogador.
        float corazul = (player.vidaAtual/player.vidaMaxima);
        float corverde = (player.vidaAtual/player.vidaMaxima);
        Cor_dano =new Color(1, corazul, corverde, 1);

        if(player.vidaAtual < player.vidaMaxima){
            rend.color = Cor_dano;
        }
        else {
            rend.color = Color.white;
        }
    }

    void ResetPosition()
    {
        // Redefina a posição para a posição inicial.
        transform.position = posRevive;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //rend.color = CorPadrao;
        rend.color = Color.white;
    }

    public void PerderVida()
    {
        player.vidaAtual -= taxaPerda * Time.deltaTime;
    }

    public void GanharVida(){
        player.vidaAtual += taxaGanho * Time.deltaTime;
    }

    

    //salvar os status do player.
    private void SavePlayerState(GameObject Player)
    {
        
        PlayerPrefs.SetFloat("PlayerPosX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", Player.transform.position.y);
        PlayerPrefs.Save();

    }

    // caso o player colida com o checkpoint a posição inicial será redefinida para que renaça no checkpoint quando morrer.
    private void OnTriggerEnter2D(Collider2D collision) {
    
        if(collision.gameObject.tag == "CheckPoint"){
            SavePlayerState(collision.gameObject);
            posRevive = transform.position;

            collision.gameObject.GetComponent<AnimCheckpoint>().AtivarCP(true);
            if(ultimoCheckPoint != null && ultimoCheckPoint != collision.gameObject)
            {
                Debug.Log("desativou ultimo checkpoint");
                ultimoCheckPoint.GetComponent<AnimCheckpoint>().AtivarCP(false);
            } else if (ultimoCheckPoint != collision.gameObject)
            {
                collision.gameObject.GetComponent<AnimCheckpoint>().TocarSomCheckpoint();
            }
            ultimoCheckPoint = collision.gameObject;
            
        }
    }

    // enquanto estiver em contato com o objeto que dará dano, ele perde vida.
    private void OnTriggerStay2D(Collider2D collision) {

        if(collision.gameObject.tag == "Corrupcao"){
            PerderVida();
            Debug.Log("perdeu vida");
        }

        if(collision.gameObject.tag == "Agua"){
            taxaPerda = 35;
            PerderVida();
            Debug.Log("perdeu vida pela agua");
            taxaPerda = 110;
        }
        
    }

    
    IEnumerator SequenciaMorte()
    {
        Debug.Log("entrou na sequencia de morte");
        movim.EstadoMorte();


        arco.SetCanShoot(false);
        
        arco.Reload();

        yield return new WaitForSeconds(delayRevive);  // tempo para a animação rodar

        transform.position = posRevive;
        movim.EstadoReviver();
        arco.SetCanShoot(true);
        
        estaMorto=false;
        player.vidaAtual = player.vidaMaxima;
        rend.color = Color.white;
    }

}
