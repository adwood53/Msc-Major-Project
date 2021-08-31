using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSetup : MonoBehaviour
{
    public Transform XRRig;
    public Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        XRRig = GameObject.Find("XR Rig").transform;
        XRRig.position = StartPosition;
    }
}
