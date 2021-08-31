using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0];
    }

    private void Update()
    {
        transform.SetPositionAndRotation(cam.transform.position, cam.transform.rotation);
    }

}
