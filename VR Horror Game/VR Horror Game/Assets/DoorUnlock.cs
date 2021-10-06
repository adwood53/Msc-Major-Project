using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.Instance.Level > 0) GetComponent<Rigidbody>().isKinematic = false;
    }

}
