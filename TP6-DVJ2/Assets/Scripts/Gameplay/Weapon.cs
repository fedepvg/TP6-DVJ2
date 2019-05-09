using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    bool OnFloor;
    float OnFloorTimer;
    const int OnFloorMaxTime=5;
    private void Start()
    {
        OnFloor = false;
    }

    private void Update()
    {
        if(OnFloor)
        {
            OnFloorTimer += Time.deltaTime;
            if(OnFloorTimer>=OnFloorMaxTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Floor")
            OnFloor = true;
    }
}
