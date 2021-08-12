using System;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class SpawnPoint : BaseTeleportationInteractable
    {
        [SerializeField]
        [Tooltip("The transform that represents the teleportation destination")]
        Transform m_TeleportAnchorTransform;
        /// <summary>
        /// The transform that represents the teleportation destination
        /// </summary>
        public Transform teleportAnchorTransform { get { return m_TeleportAnchorTransform; } set { m_TeleportAnchorTransform = value; } }

        [SerializeField] protected bool isSpawnPoint = false;

        private void OnValidate()
        {
            if (teleportAnchorTransform == null)
                teleportAnchorTransform = transform;
        }

        private void Start()
        {
            if(isSpawnPoint)
            {
                
                TeleportRequest teleportRequest = new TeleportRequest();
                teleportRequest.matchOrientation = m_MatchOrientation;
                teleportRequest.requestTime = Time.time;

                if (teleportAnchorTransform != null)
                {
                    teleportRequest.destinationPosition = m_TeleportAnchorTransform.position;
                    teleportRequest.destinationUpVector = m_TeleportAnchorTransform.up;
                    teleportRequest.destinationRotation = m_TeleportAnchorTransform.rotation;
                    teleportRequest.destinationForwardVector = m_TeleportAnchorTransform.forward;
                    m_TeleportationProvider.QueueTeleportRequest(teleportRequest);
                }
            }
        }

        protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            if (teleportAnchorTransform == null)
            {
                return false;
            }

            teleportRequest.destinationPosition = m_TeleportAnchorTransform.position;
            teleportRequest.destinationUpVector = m_TeleportAnchorTransform.up;
            teleportRequest.destinationRotation = m_TeleportAnchorTransform.rotation;
            teleportRequest.destinationForwardVector = m_TeleportAnchorTransform.forward;
            return true;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            GizmoHelpers.DrawWireCubeOriented(m_TeleportAnchorTransform.position, m_TeleportAnchorTransform.rotation, 1.0f);

            GizmoHelpers.DrawAxisArrows(m_TeleportAnchorTransform, 1.0f);
        }
    }
}
