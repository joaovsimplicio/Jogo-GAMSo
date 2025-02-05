using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    public void Sair (){
        Debug.Log("sair");
        Application.Quit();
    }

    public void Jogar (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
