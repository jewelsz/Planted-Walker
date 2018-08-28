using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera, 
            aimCamera;

    public bool aimCameraActive;
    


	// Use this for initialization
	void Start ()
    {
        aimCameraActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButton("Aim"))
        {
            mainCamera.enabled = false;
            aimCamera.enabled = true;

            aimCameraActive = true;
        }

        else
        {
            mainCamera.enabled = true;
            aimCamera.enabled = false;

            aimCameraActive = false;
        }
    }
}
