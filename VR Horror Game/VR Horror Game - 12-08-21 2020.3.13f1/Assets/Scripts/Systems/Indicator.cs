using UnityEngine;
using TMPro;

public class Indicator : MonoBehaviour
{
    MeshRenderer mr = null;
    TMP_Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        text = GetComponentInChildren<TMP_Text>();
        Deactivate();
    }

    public void Deactivate()
    {
        mr.enabled = false;
        text.enabled = false;
    }
    public void Show()
    {
        mr.enabled = true;
        text.enabled = true;
    }
    public void Hide()
    {
        mr.enabled = false;
        text.enabled = false;
    }
}
