using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenFadePass : ScriptableRenderPass
{
    private ScreenFadeFeature.FadeSettings settings = null;

    public ScreenFadePass(ScreenFadeFeature.FadeSettings newSettings)
    {
        settings = newSettings;
        renderPassEvent = newSettings.renderPassEvent;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        //Set command to store instructions
        CommandBuffer command = CommandBufferPool.Get(settings.profilerTag);

        // Get the location of our textures
        RenderTargetIdentifier source = BuiltinRenderTextureType.CameraTarget;
        RenderTargetIdentifier destination = BuiltinRenderTextureType.CurrentActive;

        // Copy texture info with added material
        command.Blit(source, destination, settings.runTimeMaterial);
        context.ExecuteCommandBuffer(command);

        // Release command
        CommandBufferPool.Release(command);
    }
}
