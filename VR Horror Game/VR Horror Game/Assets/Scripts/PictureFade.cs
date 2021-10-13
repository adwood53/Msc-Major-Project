using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFade : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    public bool isVisible = false;
    public FMODUnity.StudioEventEmitter em;

    // Start is called before the first frame update
    void Start()
    {
        // If there is no animator in the gameobject itself, get the parent animator.
        myAnimator = GetComponent<Animator>();
        if (myAnimator == null)
        {
            myAnimator = GetComponentInParent<Animator>();
        }

        if (isVisible)
        {
            myAnimator.Play("PictureFadeIn");
            em.Play();
        }
        else
        {
            myAnimator.Play("PictureFadeOut");
        }
    }

    public void Fade(bool IO)
    {
        if(IO)
        {
            myAnimator.Play("PictureFadeIn");
        }
        else
        {
            myAnimator.Play("PictureFadeOut");
        }
    }
}
