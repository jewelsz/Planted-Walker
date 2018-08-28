using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    private Transform myTransform;
    public Rigidbody rb;

    void Start ()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
    }
	
	void Update ()
    {
        attractor.Attract(myTransform);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            attractor = collision.gameObject.GetComponent<GravityAttractor>();
        }
    }
}
