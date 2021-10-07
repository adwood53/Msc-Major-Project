using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 pos;
    private Quaternion rot;
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!rb.GetComponent<Rigidbody>()) rb = null;
        pos = transform.position;
        rot = transform.rotation;
    }

    public void resetPosition()
    {
        transform.position = pos;
        transform.rotation = rot;
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
