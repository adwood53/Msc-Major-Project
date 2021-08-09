using UnityEngine;

public class Indicator : MonoBehaviour
{
    MeshRenderer mr = null;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        Deactivate();
    }

    public void Deactivate()
    {
        mr.enabled = false;
    }
    public void Show()
    {
        mr.enabled = true;
    }
    public void Hide()
    {
        mr.enabled = false;
    }
}
