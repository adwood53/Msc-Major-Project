using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdebug : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") Debug.Log("Ayyyyy");        
    }

}
