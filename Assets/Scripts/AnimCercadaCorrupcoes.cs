using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCercadaCorrupcoes : MonoBehaviour
{
    [SerializeField]float step=1f;
    Transform[] corrupcoes;

    // Start is called before the first frame update
    void Start()
    {
        corrupcoes = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //mover todas as corrupçoes filhas na direção desse transform
        foreach (Transform corr in corrupcoes)
        {
            corr.position = Vector2.MoveTowards(corr.position, this.transform.position, step*Time.deltaTime);
        }
    }
}
