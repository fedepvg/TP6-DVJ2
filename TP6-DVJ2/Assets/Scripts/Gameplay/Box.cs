using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Turret Player;
    public delegate void BoxDestroyedAction(Box box, bool onFloor);
    public BoxDestroyedAction OnBoxDestroyed;
    bool OnFloor = false;

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
            OnBoxDestroyed(this,OnFloor);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            OnFloor = true;
            BoxDestroyed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Missile")
        {
            BoxDestroyed();
            Destroy(other.gameObject);
        }
    }
}
