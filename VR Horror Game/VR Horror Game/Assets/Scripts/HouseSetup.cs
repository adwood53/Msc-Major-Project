using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSetup : MonoBehaviour
{
    public GameObject XRRig;
    public Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        XRRig = GameObject.Find("XR Rig");
        XRRig.transform.position = StartPosition;
    }
}
