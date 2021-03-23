using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponsZoom : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    bool zoomedInToggle = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomInFOV;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomOutFOV;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }

}
