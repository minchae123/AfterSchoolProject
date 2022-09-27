using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance = null;
    private CinemachineVirtualCamera vitualCamera;
    private float shakeTime;

    public static CameraShake Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (CameraShake)FindObjectOfType(typeof(CameraShake)); 
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        vitualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if(shakeTime <= 0)
            {
                CinemachineBasicMultiChannelPerlin noise = vitualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = 0;
            }
        }
    }

    public void Shake(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin noise = vitualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intensity;
        shakeTime = timer;
    }
}
