using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordaGen : MonoBehaviour
{

    [SerializeField] Rigidbody2D topo;
    [SerializeField] GameObject prefabSegmentos;
    [SerializeField] int numSegmentos = 5;


    // Start is called before the first frame update
    void Start()
    {
        Gerar();
    }


    void Gerar()
    {
        // o prefab vem com o objeto pai e o topo da corda
        // a partir do topo fazemos um for conectando cada segmento com o gerado na iteração anterior
        Rigidbody2D ultimoSeg = topo;
        for(int i = 0; i < numSegmentos; i++)
        {

            if(PertoDoChao(i))
            {
                break;
            }
            //se tivermos multiplos tipos de segmento pra variar visualmente
            //int variacao = Random.Range(0, prefabSegmentos.Length);
            GameObject novoSeg = Instantiate(prefabSegmentos);
            novoSeg.transform.parent = this.transform;
            novoSeg.transform.position = this.transform.position;
            
            HingeJoint2D novoSegHinge = novoSeg.GetComponent<HingeJoint2D>();
            novoSegHinge.connectedBody = ultimoSeg;

            ultimoSeg = novoSeg.GetComponent<Rigidbody2D>();
        }
    }

    bool PertoDoChao(int distancia)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, (float)distancia + 0.5f);
        //TODO filtrar layers do collider aqui pro player ou flechas n interromperem a geração
        return hit.collider != null;
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i = 0; i < numSegmentos; i++)
        {
            //TODO checar se esse gizmo n ta zuado
            Gizmos.DrawWireCube(new Vector3(transform.position.x, 
                                            transform.position.y-0.5f-i,
                                            0f),
                                new Vector3(.15f, .5f, 0f));
        }
    }

}
