using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject TurretBase;
    [SerializeField]
    private GameObject TurretCannon;
    [SerializeField]
    private GameObject LookTarget;
    public float PitchSpeed;
    public float YawSpeed;
    Transform BoxTransform;
    bool Rotate;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Rotate)
        {
            SetLookTargetRotation(BoxTransform);
            RotateTurret();
        }
    }

    void RotateTurret()
    {
        TurretBase.transform.rotation = Quaternion.Lerp(TurretBase.transform.rotation, LookTarget.transform.rotation, 0.005f);
        TurretBase.transform.rotation = Quaternion.Euler(new Vector3(0f, TurretBase.transform.rotation.eulerAngles.y, 0f));
        TurretCannon.transform.rotation = Quaternion.Lerp(TurretCannon.transform.rotation, LookTarget.transform.rotation, 0.009f);
        TurretCannon.transform.localRotation = Quaternion.Euler(new Vector3(TurretCannon.transform.rotation.eulerAngles.x, 0f, 0f));

    }

    public void SetLookTargetRotation(Transform t)
    {
        LookTarget.transform.LookAt(t);
        Rotate = true;
        BoxTransform = t;
    }
}
