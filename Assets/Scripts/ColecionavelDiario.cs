using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColecionavelDiario : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            
            PlayerStatus.instancia.LiberarPagina();
            Debug.Log("Objeto Coletado");

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1.0f);
            // gameObject.SetActive(false);
        }
    }
}

