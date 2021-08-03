using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMPro.TMP_Text))]

public class TextScroller : MonoBehaviour
{
    [Range(0f, 10f)] [Tooltip("Amount of time for text to fade out")] public float fadeOutTime; //Amount of time for text to fade out
    [Range(0f, 10f)] [Tooltip("Amount of time for text to fade in")] public float fadeInTime; //Amount of time for text to fade in
    [Range(0f, 100f)] [Tooltip("Amount of time that the text stays visible")] public float staticTime; //Amount of time that the text stays visible
    [Range(0f, 100f)] [Tooltip("Amount of time that the text stays hidden")] public float breakTime; //Amount of time that the text stays hidden
    [Space]
    [Tooltip("The array of strings for the Text Scroller to scroll through")] public string[] texts; //The array of strings for the Text Scroller to scroll through

    TMP_Text textField;

    int counter = 0;
    bool showing = true;

    float t1 = 0f;
    float t2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TMP_Text>();
        textField.text = texts[counter];
        counter++;
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime / (fadeOutTime*100);
        t2 += Time.deltaTime / (fadeInTime*100);
        if (!showing) textField.color = new Color(textField.color.r, textField.color.g, textField.color.b, Mathf.Lerp(textField.color.a, 0f, t1));
        if (showing) textField.color = new Color(textField.color.r, textField.color.g, textField.color.b, Mathf.Lerp(textField.color.a, 255f, t2));
    }

    IEnumerator Wait()
    {
        while (true)
        {
            if (showing) yield return new WaitForSeconds(staticTime+fadeInTime);
            if (!showing) yield return new WaitForSeconds(breakTime+fadeOutTime);
            if (!showing)
            {
                if (counter >= texts.Length) counter = 0;
                textField.text = texts[counter];
                counter++; 
            }
            showing = !showing;
            t1 = 0f; t2 = 0f;
        }
    }
}
