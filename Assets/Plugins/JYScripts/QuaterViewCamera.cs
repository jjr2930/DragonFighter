using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib
{
    [AddComponentMenu("Camera/QuaterViewCamera")]
    public class QuaterViewCamera : MonoBehaviour
    {
        [SerializeField]
        bool isOrtho = false;

        [SerializeField]
        Camera mainCamera = null;

        [SerializeField]
        Transform cameraTransform = null;

        [SerializeField]
        Transform lookingTarget = null;

        [SerializeField]
        float distance = 5f;

        [Range(1f, 90f)]
        [SerializeField]
        float lookingAngle = 45;

        [Range(0f, 360f)]
        [SerializeField]
        float rotation = 0f;

        Vector3 camToTargetDirection;

        Vector3 originVector = Vector3.right;
        float sinTheta;
        float cosTheta;
        float height;

        private void Awake()
        {
            mainCamera = Camera.main;
            cameraTransform = mainCamera.transform;
            RefreshMemberValue();
        }

        private void RefreshMemberValue()
        {
            sinTheta = Mathf.Sin(lookingAngle * Mathf.Deg2Rad);
            cosTheta = Mathf.Cos(lookingAngle * Mathf.Deg2Rad);

            camToTargetDirection.x = Mathf.Cos(rotation * Mathf.Deg2Rad);
            camToTargetDirection.z = Mathf.Sin(rotation * Mathf.Deg2Rad);

            height = distance * sinTheta;
            mainCamera.orthographic = isOrtho;
        }

        public void SetTarget(Transform target)
        {
            lookingTarget = target;
        }

        private void Update()
        {
            if (null == lookingTarget)
            {
                Debug.LogWarning("you must set target");
                return;
            }

#if UNITY_EDITOR
            RefreshMemberValue();
#endif
            Vector3 newPosition = lookingTarget.position + camToTargetDirection * distance * cosTheta;
            newPosition.y += distance * sinTheta;
            cameraTransform.position = newPosition;
            cameraTransform.LookAt(lookingTarget);
        }
    }
}