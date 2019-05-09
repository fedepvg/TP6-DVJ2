using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform Target;
    public float Speed;

    void Update()
    {
        transform.LookAt(Target.transform);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed);
    }
}
