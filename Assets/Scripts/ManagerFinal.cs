using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerFinal : MonoBehaviour
{
    [SerializeField] float duracaoFinal = 15f;
    [SerializeField] float tempoEscolha = 20f;
    bool timerAtivo = false;
    float tempo;

    Animator anim;
    //Collider2D coll;

    [SerializeField] Slider timerSlider;
    [SerializeField] ImagemFinalSelector imgSel;
    [SerializeField] PlayableDirector cutscene;
    [SerializeField] GameObject painelBotoesFinal;



    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponentInChildren<Animator>();
        //coll = GetComponentInChildren<Collider2D>();

        timerSlider.maxValue = tempoEscolha;
        timerSlider.value = tempoEscolha;
        tempo = tempoEscolha;
    }

    void Update()
    {
        if(timerAtivo)
        {
            tempo -= Time.deltaTime;
            timerSlider.value = tempo;
        }

        if(tempo <= 0f)
        {
            IniciarFinal(2);
        }
    }

    public void IniciarFinal(int img)
    {
        Debug.Log("final iniciado: " + img);
        timerAtivo = false;
        painelBotoesFinal.SetActive(false);
        imgSel.SetImagemFinal(img);
        anim.SetTrigger("FINAL");
        StartCoroutine(MudarCena());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovimento>().ToggleMovimento(false);
            //anim.SetTrigger("FINAL");
            //StartCoroutine(MudarCena());

            //COMEÇAR CUTSCENE AQ
            //NO FINAL DELA MOSTRAR A ESCOLHA E LIGAR O TIMER
            cutscene.Play();

        }
    }

    IEnumerator MudarCena()
    {
        yield return new WaitForSeconds(duracaoFinal);  // tempo para o vídeo rodar
        PlayerStatus.instancia.GetComponentInChildren<PlayerMira>().MiraAtiva(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public void ToggleTimer(bool toggle)
    {
        timerAtivo = toggle;
    }

}
