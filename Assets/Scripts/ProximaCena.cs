using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ProximaCena : MonoBehaviour
{
    [SerializeField] float tempoVideo = 22f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarregarMenu());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator CarregarMenu() {
        yield return new WaitForSeconds(tempoVideo);  // tempo para o vídeo rodar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
