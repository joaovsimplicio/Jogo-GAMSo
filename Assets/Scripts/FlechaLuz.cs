using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaLuz : Flecha
{
    override protected void OnTriggerStay2D(Collider2D other){
        base.OnTriggerStay2D(other);
        if(other.gameObject.CompareTag("Corrupcao")){
            EfeitoColisao();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(!other.gameObject.CompareTag("Player")){
            rb.velocity = Vector2.zero;
        }
    }
}

