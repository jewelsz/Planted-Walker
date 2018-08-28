using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShootScript : MonoBehaviour
{
    [SerializeField]
    SwitchCamera switchCamera;
    [SerializeField]
    HookScript hookScript;
    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    MoveTowardsHook moveToHook;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Camera aimCamera;

    Vector3 cameraRotation;

    GameObject bullet;

    void Update()
    {
        // When LeftShift pressed, Shoot
        if (switchCamera.aimCameraActive && Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Shoot if there is no other bullet
            if (bullet == null)
            {
                Fire();
            }
            else
            {
                Destroy(bullet);
                Fire();
            }
        }

        if(bullet != null && Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement.movingDisabled = true;
            moveToHook.moveTowardsHook();
        }
    }


    void Fire()
    {
        getCameraRotation();

        // Create the Bullet from the Bullet Prefab
            bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Change bullet rotation to match camera look rotation
        bullet.transform.eulerAngles = new Vector3(cameraRotation.x - 1, cameraRotation.y, cameraRotation.z);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 10 seconds
        if (hookScript.thisDestroy)
        {
            Destroy(bullet, 10.0f);
        }
    }
    
    void getCameraRotation()
    {
        cameraRotation = aimCamera.transform.eulerAngles;
    }
}
