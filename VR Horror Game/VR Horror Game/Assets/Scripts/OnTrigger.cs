using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [Tooltip("The collider tag that will trigger the event.")]
    public string ColliderTag = "Player";
    [Tooltip("Calls when trigger is entered.")]
    public UnityEvent Enter;
    [Tooltip("Calls when trigger is exitted.")]
    public UnityEvent Exit;

    private void Start()
    {
        if (Enter == null)
            Enter = new UnityEvent();

        if (Exit == null)
            Exit = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ColliderTag) Enter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ColliderTag) Exit.Invoke();
    }
}
