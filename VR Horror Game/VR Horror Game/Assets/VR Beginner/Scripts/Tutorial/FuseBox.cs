﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public ParticleSystem[] SparkleFuseVFX;
    public ParticleSystem[] SwitchedOnVFX;
    public ParticleSystem[] SwitchedOffVFX;

    public GameObject light;
    bool m_FusePresent = false;

    public void Switched(int step)
    {
        if (!m_FusePresent)
            return;

        if (step == 0)
        {
            foreach (var s in SwitchedOffVFX)
            {
                light.SetActive(true);
                s.Play();
            }
        }
        else
        {
            foreach (var s in SwitchedOnVFX)
            {
                light.SetActive(false);
                s.Play();
            }
        }
    }
    
    public void FuseSocketed(bool socketed)
    {
        m_FusePresent = socketed;

        if (m_FusePresent)
        {
            foreach (var s in SparkleFuseVFX)
            {
                s.Play();
            }
        }
    }
}
