using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColecionavelAnel : MonoBehaviour
{
    public float amp;
    public float freq;
    public tipoFlecha tipo;
   
    void Update()
    {
        // Movimenta para cima e para baixo
        transform.position += Vector3.up * amp * freq * Mathf.Cos(freq * Time.time) * Time.deltaTime; 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            // Desativa todos os componentes e espera o efeito sonoro tocar para destruir objeto
            PlayerStatus.instancia.LiberarFlecha(tipo);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<ParticleSystem>().Stop();

            if(gameObject.TryGetComponent<Light2D>(out Light2D luz))
            {
                luz.enabled = false;
            }
            Destroy(gameObject, 4.0f);
        }
    }


}
