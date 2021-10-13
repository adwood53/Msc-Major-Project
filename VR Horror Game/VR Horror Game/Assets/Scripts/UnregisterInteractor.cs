using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnregisterInteractor : MonoBehaviour
{
    //This script attempts to unregister the xrgrabinteractable before it is deleted via scene loading. This is due to a XR Interaction Manager bug that crashes the manager when a interactable is deleted whilst an interactor is within its collider.

    public XRBaseInteractable xrBaseInteractable;

    public void Unregister()
    {
        if (xrBaseInteractable != null) xrBaseInteractable.colliders.Clear();
        else Debug.LogError("UnregisterInteractor scipt missing reference to xrBaseInteractable on " + this.transform.name);
    }
}
