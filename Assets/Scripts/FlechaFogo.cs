using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FlechaFogo : Flecha
{
        [SerializeField] GameObject aguaPreFab;
        public AudioSource SFX_madeira, SFX_gelo;
        private bool JaColidiu = false;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Madeira") && JaColidiu == false){
            EfeitoColisao();
            SFX_madeira.pitch = Random.Range(0.9f, 1.1f);
            SFX_madeira.Play();
            Destroy(other.gameObject);
            //TESTE DE SCREENSHAKE PRA DPS
            //ScreenShake.shakeAtivo.Shake(1f, 0.2f);
            JaColidiu = true;
        }

        if(other.gameObject.CompareTag("Gelo") && JaColidiu == false){   
            EfeitoColisao();
            SFX_gelo.Play();
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            //aguaPreFab.transform.localScale = other.gameObject.transform.localScale;
            aguaPreFab.GetComponent<SpriteRenderer>().size = other.gameObject.GetComponent<SpriteRenderer>().size;
            
            Destroy(other.gameObject);
            Instantiate(aguaPreFab, position, rotation);

            JaColidiu = true;
        }
        if(!other.gameObject.CompareTag("Player")){
            rb.velocity = Vector2.zero;
        }
    }
}

