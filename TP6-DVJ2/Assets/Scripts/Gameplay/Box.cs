using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private Turret Player;
    //private Turret player;

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Player.SetLookTargetRotation(this.transform);
    }
}
