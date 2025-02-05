using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeGelo : MonoBehaviour
{
    SpriteRenderer sprt;
    [SerializeField] SpriteRenderer sprtAgua = null;
    BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        //atribui direto do editor q tava dando ruim aqui
        //sprtAgua = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        coll.size = sprt.size;

        if (sprtAgua != null)
        {
            sprtAgua.size = sprt.size;
        }
    }

}
