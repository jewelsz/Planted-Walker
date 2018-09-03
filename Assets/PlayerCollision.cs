using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]
    MoveTowardsHook moveTowardsHook;
    [SerializeField]
    PlayerMovement playermovement;
    [SerializeField]
    HookShootScript hookShoot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grapple Hook"))
        {
            moveTowardsHook.stopMovement();
            playermovement.movingDisabled = false;
            hookShoot.destroyBullet();
        }
    }
}
