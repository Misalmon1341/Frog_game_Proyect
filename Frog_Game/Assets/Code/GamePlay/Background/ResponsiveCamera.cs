using System;
using UnityEngine;

public class ResponsiveCamera : MonoBehaviour
{
    [SerializeField] private Vector3 cameraTabletPosition;
    [SerializeField] private Vector3 cameraMobilePosition;

    private void Start()
    {
        UpdateCameraPosition();
        ResponsiveManager.Instance.OnScreenSizeChanged.AddListener(UpdateCameraPosition);
    }

    public void UpdateCameraPosition()
    {
        if (ResponsiveManager.Instance.CurrentDeviceType == DeviceType.Tablet)
        {
          gameObject.transform.position = cameraTabletPosition;
        }
        else if (ResponsiveManager.Instance.CurrentDeviceType == DeviceType.Mobile)
        { 
            gameObject.transform.position = cameraMobilePosition;
        }
    }
}
