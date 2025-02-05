using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoCamera : MonoBehaviour
{
    public GameObject virtualCam;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(true);
            EfeitoScreenShake.shakeAtivo = this.GetComponentInChildren<EfeitoScreenShake>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger){
            virtualCam.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        PolygonCollider2D coll = GetComponent<PolygonCollider2D>();

        Vector3 p1, p2;
        int npontos = coll.points.Length;
        for (int i = 0; i < npontos; i++)
        {

            p1 = new Vector3(coll.points[i].x+transform.position.x, 
                             coll.points[i].y+transform.position.y, 
                             0f);
            if(i+1<npontos)
            {
                p2 = new Vector3(coll.points[i+1].x+transform.position.x, 
                                 coll.points[i+1].y+transform.position.y, 
                                 0f);
            } else
            {
                p2 = new Vector3(coll.points[0].x+transform.position.x, 
                                 coll.points[0].y+transform.position.y, 
                                 0f);
            }
            
            Gizmos.DrawLine(p1, p2);
        }

    }
}
