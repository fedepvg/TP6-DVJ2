using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Turret Player;
    public delegate void BoxDestroyedAction(Box box);
    public BoxDestroyedAction OnBoxDestroyed;

    private void OnMouseDown()
    {
        Player.SetLookTargetRotation(this.transform);
    }

    private void BoxDestroyed()
    {
        DestroyAsDispatcher();
    }

    private void DestroyAsDispatcher()
    {
        if(OnBoxDestroyed!=null)
        {
            OnBoxDestroyed(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Missile")
        {
            BoxDestroyed();
            Destroy(collision.collider.gameObject);
        }
    }
}
