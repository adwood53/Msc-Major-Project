using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskRaiser : MonoBehaviour
{
    public GameObject wave1;
    public float wave1time;
    public GameObject wave2;
    public float wave2time;
    public GameObject wave3;
    public float wave3time;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("wavecycle");
    }

    IEnumerator wavecycle()
    {
        switch (counter)
        {
            default:
                break;
            case 0:
                yield return new WaitForSeconds(wave1time);
                wave1.SetActive(true);
                break;
            case 1:
                yield return new WaitForSeconds(wave2time - wave1time);
                wave2.SetActive(true);
                break;
            case 2:
                yield return new WaitForSeconds(wave3time - wave2time - wave1time);
                wave3.SetActive(true);
                break;
        }
        counter++;
        if(counter < 3) StartCoroutine("wavecycle");
    }
}
