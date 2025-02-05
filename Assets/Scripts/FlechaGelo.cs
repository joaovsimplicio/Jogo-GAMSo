using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaGelo : Flecha
{
    [SerializeField] GameObject geloPreFab;

    private bool JaColidiu = false;
    
    override protected void OnTriggerEnter2D(Collider2D other){
        base.OnTriggerEnter2D(other);
        if(other.gameObject.CompareTag("Agua") && JaColidiu == false && !retornando){
            EfeitoColisao();
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            GetComponent<AudioSource>().Play();
            Vector2 position = other.gameObject.transform.position;
            Quaternion rotation = other.gameObject.transform.rotation;
            
            //geloPreFab.transform.localScale = other.gameObject.transform.localScale;
            geloPreFab.GetComponent<SpriteRenderer>().size = other.gameObject.GetComponent<SpriteRenderer>().size;
            
            Destroy(other.gameObject);
            Instantiate(geloPreFab, position, rotation);

            Debug.Log("agua");

            JaColidiu = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(!other.gameObject.CompareTag("Player")){
            rb.velocity = Vector2.zero;
        }
    }
}
