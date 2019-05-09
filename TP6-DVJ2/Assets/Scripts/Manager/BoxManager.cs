using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    GameObject BoxPrefab;
    [SerializeField]
    Collider SpawnArea;
    List<Box> Boxes = new List<Box>();
    const int BoxQuant = 10;
    [SerializeField]
    GameObject WeaponPrefab;
    float BoxSpawnTimer;
    const int BoxSpawnCooldown = 5;
    int ActualBox;
    [SerializeField]
    private GameManager gameManager;
    private int BoxesLeft;

    void Start()
    {
        BoxSpawnTimer = 0f;
        ActualBox = 0;
        for (int i = 0; i < BoxQuant;i++)
        {
            GameObject go = Instantiate(BoxPrefab);
            Box b = go.GetComponent<Box>();
            Turret player = GameObject.Find("Turret").GetComponent<Turret>();

            b.OnBoxDestroyed += SpawnWeapons;
            b.OnBoxDestroyed += BoxDestroyedAsADispatcher;
            Boxes.Add(b);
            Boxes[i].Player = player;
            Boxes[i].gameObject.SetActive(false);
            BoxesLeft = BoxQuant;
        }
        SpawnBox();
    }

    private void Update()
    {
        BoxSpawnTimer += Time.deltaTime;
        if(BoxSpawnTimer>=BoxSpawnCooldown)
        {
            SpawnBox();
            BoxSpawnTimer = 0;
        }
        if(BoxesLeft<=0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void SpawnBox()
    {
        for(int i=ActualBox;i<BoxQuant;i++)
        {
            if(!Boxes[i].gameObject.activeSelf)
            {
                Boxes[i].gameObject.SetActive(true);
                Boxes[i].transform.position = new Vector3(Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x), SpawnArea.bounds.center.y,
                                                        Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z));
                Boxes[i].transform.rotation = Quaternion.identity;
                ActualBox++;
                return;
            }
        }
    }

    private void BoxDestroyedAsADispatcher(Box b,bool onFloor)
    {
        BoxesLeft--;
        GameManager.Instance.AddBoxDestroyed(onFloor);
        Destroy(b.gameObject);
    }

    private void SpawnWeapons(Box b, bool onFloor)
    {
        if(!onFloor)
        {
            Instantiate(WeaponPrefab, b.transform.position, Quaternion.identity);
        }
    }
}
