using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBotaoTutorial : MonoBehaviour
{
    [SerializeField] GameObject painelTutorial;
    PlayerStatus player;

    void Start()
    {
        player = PlayerStatus.instancia;
    }

    public void ToggleTutorial(bool toggle)
    {
        painelTutorial.SetActive(toggle);

        player.ToggleMovMira(!toggle);
        MenuPausa.podePausar = !toggle;
        MenuDiario.podeUsarDiario = !toggle;
        
        gameObject.GetComponent<AudioSource>().Play();

    }

}
