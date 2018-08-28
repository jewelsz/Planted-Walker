using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    public float zoomSensitivity = 15.0f;
    public float zoomSpeed = 5.0f;
    public float zoomMin = -3.5f;
    public float zoomMax = 0f;

    private float zoom;


    void Start()
    {
    }

    void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
    }

    void LateUpdate()
    {
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * zoomSpeed);
    }
}
