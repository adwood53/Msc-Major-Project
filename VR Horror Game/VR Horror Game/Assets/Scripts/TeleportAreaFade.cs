using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportAreaFade : TeleportationArea
{
    public ScreenFader screenFade = null;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (teleportTrigger == TeleportTrigger.OnSelectEnter)
            SendTeleportRequest(interactor, base.onSelectEnter);
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        if (teleportTrigger == TeleportTrigger.OnSelectExit)
            SendTeleportRequest(interactor, base.onSelectExit);
    }
    protected override void OnActivate(XRBaseInteractor interactor)
    {
        if (teleportTrigger == TeleportTrigger.OnActivate)
            SendTeleportRequest(interactor, base.onActivate); ;
    }
    protected override void OnDeactivate(XRBaseInteractor interactor)
    {
        if (teleportTrigger == TeleportTrigger.OnDeactivate)
            SendTeleportRequest(interactor, base.onDeactivate);
    }
    private IEnumerator FadeSequence(UnityEvent<XRBaseInteractor> actionEvent, XRBaseInteractor interactor, RaycastHit raycastHit, TeleportRequest tr)
    {
        float duration = screenFade.duration;

        yield return new WaitForSeconds(screenFade.FadeIn());

        if (GenerateTeleportRequest(interactor, raycastHit, ref tr))
        {
            m_TeleportationProvider.QueueTeleportRequest(tr);
        }
        actionEvent.Invoke(interactor);

        screenFade.FadeOut();
    }
    private void OnValidate()
    {
        if (!screenFade)
            screenFade = FindObjectOfType<ScreenFader>();
    }

    void SendTeleportRequest(XRBaseInteractor interactor, UnityEvent<XRBaseInteractor> actionEvent)
    {
        if (!interactor || m_TeleportationProvider == null)
            return;

        XRRayInteractor rayInt = interactor as XRRayInteractor;
        if (rayInt != null)
        {
            RaycastHit raycastHit;
            if (rayInt.GetCurrentRaycastHit(out raycastHit))
            {
                // are we still selecting this object   
                bool found = false;
                for (int i = 0; i < colliders.Count; i++)
                {
                    if (colliders[i] == raycastHit.collider)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    TeleportRequest tr = new TeleportRequest();
                    tr.matchOrientation = m_MatchOrientation;
                    tr.requestTime = Time.time;
                    StartCoroutine(FadeSequence(actionEvent, interactor, raycastHit, tr));
                }
            }
        }
    }
}
