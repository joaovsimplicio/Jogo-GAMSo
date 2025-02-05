using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoFrameFreeze : MonoBehaviour
{
    [SerializeField] [Range(0f, .5f)]
    float duracao = .1f;
    static bool jogoCongelado = false;
    float timescaleInicial;

    public void Congelar()
    {
        if(!jogoCongelado && !MenuPausa.jogoPausado)
        {
            timescaleInicial = Time.timeScale;
            Time.timeScale = 0f;
            StartCoroutine(Esperar(duracao));
        }
    }

    IEnumerator Esperar(float dur)
    {
        jogoCongelado = true;
        yield return new WaitForSecondsRealtime(dur);
        Time.timeScale = timescaleInicial;
        jogoCongelado = false;
    }
}
