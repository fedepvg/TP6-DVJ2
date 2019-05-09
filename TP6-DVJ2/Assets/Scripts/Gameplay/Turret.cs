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
    [SerializeField]
    private GameObject MissilePrefab;
    public float PitchSpeed;
    public float YawSpeed;
    Transform BoxTransform;
    bool Rotate;
    float RayDistance = 100;
    public LayerMask RayCastLayer;
    private Missile ActiveMissile;

    void Update()
    {
        if (Rotate)
        {
            SetLookTargetRotation(BoxTransform);
            RotateTurret();
        }

        RaycastHit hit;

        if (Physics.Raycast(TurretCannon.transform.position, TurretCannon.transform.forward, out hit, RayDistance, RayCastLayer))
        {
            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "Box":
                    ShootMissile();
                    break;
            }
            Debug.DrawRay(TurretCannon.transform.position, TurretCannon.transform.forward * hit.distance);
        }
        else
        {
            Debug.DrawRay(TurretCannon.transform.position, TurretCannon.transform.forward * hit.distance);
        }
        
    }

    void RotateTurret()
    {
        TurretBase.transform.rotation = Quaternion.LerpUnclamped(TurretBase.transform.rotation, LookTarget.transform.rotation, YawSpeed*Time.deltaTime);
        TurretBase.transform.rotation = Quaternion.Euler(new Vector3(0f, TurretBase.transform.rotation.eulerAngles.y, 0f));
        TurretCannon.transform.rotation = Quaternion.LerpUnclamped(TurretCannon.transform.rotation, LookTarget.transform.rotation, PitchSpeed * Time.deltaTime);
        TurretCannon.transform.localRotation = Quaternion.Euler(new Vector3(TurretCannon.transform.rotation.eulerAngles.x, 0f, 0f));

    }

    public void SetLookTargetRotation(Transform t)
    {
        LookTarget.transform.LookAt(t);
        Rotate = true;
        BoxTransform = t;
    }

    private void ShootMissile()
    {
        if (!ActiveMissile)
        {
            GameObject go = Instantiate(MissilePrefab, TurretCannon.transform.position, TurretCannon.transform.rotation);
            ActiveMissile = go.GetComponent<Missile>();
            ActiveMissile.Target = BoxTransform;
            Rotate = false;
        }
    }
}
