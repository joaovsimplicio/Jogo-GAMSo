using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class EfeitoScreenShake : MonoBehaviour
{
    public static EfeitoScreenShake shakeAtivo;

    CinemachineVirtualCamera cam;
    CinemachineBasicMultiChannelPerlin noise;

    float timer, timeratual, initIntense;

    // Start is called before the first frame update
    void Start()
    {
        shakeAtivo = this;

        cam = GetComponent<CinemachineVirtualCamera>();
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                noise.m_AmplitudeGain = Mathf.Lerp(initIntense, 0f, (1-(timeratual/timer)));
            }
        }
    }

    public void Shake(float intensidade, float frequencia, float tempo)
    {
        noise.m_AmplitudeGain = intensidade;
        noise.m_FrequencyGain = frequencia;
        initIntense = intensidade;
        timer = tempo;
        timeratual = tempo;
    }

    public void StopShake()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
