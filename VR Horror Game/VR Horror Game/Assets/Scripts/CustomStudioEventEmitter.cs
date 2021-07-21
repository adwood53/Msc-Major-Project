using System;
using UnityEngine;
using FMODUnity;

[AddComponentMenu("FMOD Studio/Custom Studio Event Emitter")]
public class CustomStudioEventEmitter : StudioEventEmitter
{
    public GameObject[] setActiveWithStart;
    void Start()
    {
        foreach (var item in setActiveWithStart) item.SetActive(IsActive);
    }
}
