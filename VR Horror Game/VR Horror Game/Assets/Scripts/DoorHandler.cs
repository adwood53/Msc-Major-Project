using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    public Transform Handler;
    private Rigidbody rb;

    public void ResetPosition()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.transform.SetPositionAndRotation(Handler.position, Handler.rotation);
        
    }
}
