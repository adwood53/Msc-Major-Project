using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//Needs updating to URP

public class ScreenFader : MonoBehaviour
{
    public ForwardRendererData rendererData = null;

    [Range(0, 1)] public float alpha = 0.0f;
    [Range(0, 5)] public float duration = 0.5f;

    private Material fadeMaterial = null;

    private void Start()
    {
        SetupFadeFeature();
    }

    private void SetupFadeFeature()
    {
        ScriptableRendererFeature feature = rendererData.rendererFeatures.Find(item => item is ScreenFadeFeature);

        if (feature is ScreenFadeFeature screenFade)
        {
            fadeMaterial = Instantiate(screenFade.settings.material);
            screenFade.settings.runTimeMaterial = fadeMaterial;
        }

        FadeOut();
    }

    public float FadeIn()
    {
        StartCoroutine(LerpMaterialAlpha(0f, 1f));
        return duration;
    }

    public float FadeOut()
    {
        StartCoroutine(LerpMaterialAlpha(1f, 0f));
        return duration;
    }

    public float FadeInInstant()
    {
        fadeMaterial.SetFloat("_Alpha", 1.0f);
        return duration;
    }

    public float FadeOutInstant()
    {
        fadeMaterial.SetFloat("_Alpha", 0.0f);
        return duration;
    }

    IEnumerator LerpMaterialAlpha(float startValue, float endValue)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            alpha = Mathf.Lerp(startValue, endValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            fadeMaterial.SetFloat("_Alpha", alpha);

            yield return null;
            Debug.Log(alpha);
        }

        alpha = endValue;
        fadeMaterial.SetFloat("_Alpha", alpha);
    }

}
