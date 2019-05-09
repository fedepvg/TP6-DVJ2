using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    Vector3 LastBoxPos;

    void Update()
    {
        if (Target)
        {
            transform.LookAt(Target.transform);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed);
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
