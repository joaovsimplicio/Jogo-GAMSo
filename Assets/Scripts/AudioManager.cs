using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;
    AudioSource asource;
    
    void Awake() 
    {
        if (instancia == null)
        {
            instancia = this;
            //DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    public void SwitchMute()
    {
        asource.mute = !asource.mute;
    }

}
