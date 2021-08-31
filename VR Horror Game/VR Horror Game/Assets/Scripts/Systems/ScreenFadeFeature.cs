using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenFadeFeature : ScriptableRendererFeature
{
    public FadeSettings settings = null;
    private ScreenFadePass renderPass = null;

    public override void Create()
    {
        // create a new pass using these settings
        renderPass = new ScreenFadePass(settings);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        // Add the pass
        if (settings.AreValid())
            renderer.EnqueuePass(renderPass);
    }

    [Serializable]
    public class FadeSettings
    {
        public bool isEnabled = true;
        public string profilerTag = "Screen Fade";

        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
        public Material material = null;

        [NonSerialized] public Material runTimeMaterial = null;

        public bool AreValid()
        {
            return ((runTimeMaterial != null) && isEnabled);
        }
    }

}
