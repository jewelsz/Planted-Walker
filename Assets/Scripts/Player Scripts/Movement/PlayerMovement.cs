using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpSpeed = 2f;
    private float distance = 5f;
    private float turnSpeed;

    private bool jumping;
    private bool walking;
    public bool movingDisabled;

    public Transform GameCamera;

    //private Vector3 moveDir;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumping = false;
        walking = false;
        movingDisabled = false;
        turnSpeed = 100f;
    }

    void FixedUpdate()
    {
        if (!movingDisabled)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            transform.Translate(speed * moveHorizontal * Time.deltaTime, 0f, speed * moveVertical * Time.deltaTime);

            Quaternion neededRotation = GameCamera.transform.rotation;
            neededRotation.x = 0;
            neededRotation.z = 0;


            if (Input.GetKeyUp(KeyCode.Space) && jumping == false)
            {
                jump();
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 40f);
            }
            else
            {

                if (GameCamera.transform.rotation.y - rb.transform.rotation.y > 0.1 || GameCamera.transform.rotation.y - rb.transform.rotation.y < -0.1)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 40f);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Planet"))
        {
            jumping = false;
        }
    }

    private void jump()
    {
        rb.AddRelativeForce(Vector3.up * jumpSpeed * 100);
        jumping = true;
    }
}
