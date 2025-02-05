using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlatMovel : MonoBehaviour
{
    public float velocidade;    // velocidade da plataforma
    public int pontoInicial;    // posição inicial da plataforma
    public Transform[] pontos;  // posições que a plataforma toma
    private int i;
    private float y;
    void Start()
    {
        transform.position = pontos[pontoInicial].position;
    }
    void Update()
    {
        y = gameObject.transform.position.y;
        // se plataforma tiver muito perto do ponto onde tem que ir ...
        if(Vector2.Distance(transform.position, pontos[i].position) < 0.02f) {
            // passe para o próximo ou comece do 0
            i++;
            if(i == pontos.Length) {
                i = 0;
            }
        }
        // move a plataforma para o próximo ponto da array
        transform.position = Vector2.MoveTowards(transform.position, pontos[i].position, velocidade*Time.deltaTime);
    }
    // quando player sobe na plataforma, gruda nele fazendo-o filho
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > y + 0.5) {
            other.transform.SetParent(transform);
        }
    }
    // quando player sai da plataforma, desgruda
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        int i = pontoInicial;
        do{
            Gizmos.DrawLine(pontos[i].position, pontos[(i+1)%pontos.Length].position);
            i = (i+1)%pontos.Length;

        }while(i!=pontoInicial);
    }
}
