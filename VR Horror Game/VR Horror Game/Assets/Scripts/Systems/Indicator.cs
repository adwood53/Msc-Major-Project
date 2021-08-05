using UnityEngine;

public class Indicator : MonoBehaviour
{
    Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        Deactivate();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
        animator.SetBool("Show", true);
    }
    public void Hide()
    {
        animator.SetBool("Show", false);
    }
}
