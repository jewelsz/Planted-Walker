using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;
    private Transform myTransform;
    public Rigidbody rb;
    MoveTowardsHook moveTowardshook;
    bool disable;

    void Start ()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
        disable = false;
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

    public void disableGravity()
    {
        disable = true;
    }

    public void enableGravity()
    {
        disable = false;
    }
}
