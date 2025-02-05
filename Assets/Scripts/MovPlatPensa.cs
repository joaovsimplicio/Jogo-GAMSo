using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlatPensa : MonoBehaviour
{
    private float y0, y, yMax, yMin, t, timeStamp;
    private Boolean playerEncima;
    public float tolerancia, dist, k;
    void Start()
    {
        playerEncima = false;
        timeStamp = Time.time;
        y0 = gameObject.transform.position.y;
        yMax = y0 + dist/2;
        yMin = yMax - dist;
    }

    void Update()
    {
        t = Time.time - timeStamp;
        y = gameObject.transform.position.y;
        if(playerEncima && y > yMin + tolerancia*dist) {
            // descer a plataforma se estiver muito alta
            transform.position += Vector3.up * (yMin - y0)*k*Mathf.Exp(-k*t)*Time.deltaTime;
        } else if(!playerEncima && y < yMax - tolerancia*dist) {
            // subir a plataforma se estiver muito baixa
            transform.position += Vector3.up * (yMax - y0)*k*Mathf.Exp(-k*t)*Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && other.gameObject.transform.position.y > y0 + 0.5) {
            playerEncima = true;
            timeStamp = Time.time;
            y0 = gameObject.transform.position.y;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            playerEncima = false;
            timeStamp = Time.time;
            y0 = gameObject.transform.position.y;
        }
    }
}
