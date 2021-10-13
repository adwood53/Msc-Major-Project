using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] Transform forceposition;
    [SerializeField] bool isExplosion = false;
    [SerializeField] float explosionRadius = 0.5f;
    [SerializeField] float Force = 200f;
    Rigidbody rb;
    [SerializeField] bool trigger = false;
    [SerializeField] bool stopSleeping = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(stopSleeping) rb.sleepThreshold = 0.001f;
    }

    private void Update()
    {
        if (trigger) addForce();
        trigger = false;
    }

    public void addForce()
    {
        if(isExplosion)
        {
            rb.AddExplosionForce(Force, forceposition.position, explosionRadius, 0.0f, ForceMode.Force);
        }
        else
        {
            rb.AddForceAtPosition(((transform.position - forceposition.position) * Force), forceposition.position, ForceMode.Acceleration);
        }
    }
}
