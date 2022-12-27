using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    public ParticleSystem cubeEx;
    public static ExplosionFX Instance;
    ParticleSystem.MainModule cubeFXModule;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cubeFXModule = cubeEx.main;
    }

    public void PlayerCubeExplosion(Vector3 pos, Color color)
    {
        cubeFXModule.startColor = new ParticleSystem.MinMaxGradient(color);
        cubeEx.transform.position = pos;
        cubeEx.Play();
    }
}
