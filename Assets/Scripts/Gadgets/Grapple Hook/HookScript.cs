using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public bool thisDestroy;
    
	// Use this for initialization
	void Start ()
    {
        thisDestroy = true;
	}
	
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            thisDestroy = false;
            setPosition();
        }
    }

    private void setPosition()
    {
        //transform.Translate(transform.position);
        m_Rigidbody = GetComponent<Rigidbody>();
        
        //Freeze position
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
}
