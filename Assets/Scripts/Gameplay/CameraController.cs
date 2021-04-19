using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float XMinRotation = -45f;
    private float XMaxRotation = 45f;
    private float YMinRotation = -75f;
    private float YMaxRotation = 90f;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    [Range(1.0f, 10.0f)]
    public float XSensitivity;

    [SerializeField]
    [Range(1.0f, 10.0f)]
    private float YSensitivity;

    private float rotAroundX, rotAroundY;
    private bool allowMovement;

    private void Start()
    {
        EnableCameraMovement();
        GetStartRotation();
    }

    private void Update()
    {
        CameraMovement();
    }

    private void GetStartRotation()
    {
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
    }

    private void CameraMovement()
    {
        if (allowMovement)
        {
            rotAroundX += Input.GetAxis("Mouse Y") * XSensitivity;
            rotAroundY += Input.GetAxis("Mouse X") * YSensitivity;

            // Clamp rotation
            rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
            rotAroundY = Mathf.Clamp(rotAroundY, YMinRotation, YMaxRotation);

            cam.transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0);
        } 
    }

    public void EnableCameraMovement()
    {
        Cursor.visible = false;
        allowMovement = true;
    }

    public void DisableCameraMovement()
    {
        Cursor.visible = true;
        allowMovement = false;
    }
}
