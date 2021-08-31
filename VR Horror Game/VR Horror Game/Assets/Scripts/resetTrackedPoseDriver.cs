using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class resetTrackedPoseDriver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        if (devices.Count != 0)
        {
            devices[0].subsystem.TryRecenter();
        }
    }

}
