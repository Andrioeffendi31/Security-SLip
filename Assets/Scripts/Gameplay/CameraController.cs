using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    private float XMinRotation = -45f;
    private float XMaxRotation = 45f;
    private float YMinRotation = -75f;
    private float YMaxRotation = 90f;

    public GameObject chair;

    [Range(1.0f, 10.0f)]
    public float XSensitivity;
    [Range(1.0f, 10.0f)]
    public float YSensitivity;
    private float rotAroundX, rotAroundY;

    private void Start()
    {
        cam = GetComponent<Camera>();
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
    }

    private void Update()
    {
        rotAroundX += Input.GetAxis("Mouse Y") * XSensitivity;
        rotAroundY += Input.GetAxis("Mouse X") * YSensitivity;

        // Clamp rotation
        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
        rotAroundY = Mathf.Clamp(rotAroundY, YMinRotation, YMaxRotation);

        CameraRotation();
    }

    private void CameraRotation()
    {
        chair.transform.parent.rotation = Quaternion.Euler(0, rotAroundY, 0);
        cam.transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0);
    }
}
