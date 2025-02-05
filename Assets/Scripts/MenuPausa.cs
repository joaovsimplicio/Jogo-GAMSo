using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool jogoPausado = false;
    public static bool podePausar = true;
    public GameObject PausaMenuCanvas;
    private PlayerStatus player;

    void Start()
    {
        Time.timeScale = 1f;
        player = PlayerStatus.instancia;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && podePausar)
        {
            if(jogoPausado)
            {
                Jogar();
            }
            else 
            {
                Parar();
            }
        }
    }

    void Parar()
    {
        PausaMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        
        jogoPausado = true;

        MenuDiario.podeUsarDiario = false;

        player.ToggleMovMira(false);
        
    }

    public void Jogar()
    {
        PausaMenuCanvas.SetActive(false);
        Time.timeScale = 1f;

        jogoPausado = false;

        MenuDiario.podeUsarDiario = true;

        if (!MenuDiario.DiarioAberto)
        {
            player.ToggleMovMira(true);
        }
        
    }

    public void MenuPrincipal()
    {
        //TODO quando botar a cena do video antes da do jogo talvez tenha q mudar aq
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
 
}