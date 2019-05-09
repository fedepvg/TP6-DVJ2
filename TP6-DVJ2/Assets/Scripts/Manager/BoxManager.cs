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

    void Start()
    {
        BoxSpawnTimer = 0f;

        for (int i = 0; i < BoxQuant;i++)
        {
            GameObject go = Instantiate(BoxPrefab, new Vector3(i * 2 - 10, 1, 0), Quaternion.identity);
            Box b = go.GetComponent<Box>();
            Turret player = GameObject.Find("Turret").GetComponent<Turret>();

            b.OnBoxDestroyed += SpawnWeapons;
            b.OnBoxDestroyed += BoxDestroyedAsADispatcher;
            Boxes.Add(b);
            Boxes[i].Player = player;
            Boxes[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        BoxSpawnTimer += Time.deltaTime;
        if(BoxSpawnTimer>=BoxSpawnCooldown)
        {
            SpawnBox();
            BoxSpawnTimer = 0;
        }
    }

    private void SpawnBox()
    {
        for(int i=0;i<BoxQuant;i++)
        {
            if(!Boxes[i].gameObject.activeSelf)
            {
                Boxes[i].gameObject.SetActive(true);
                Boxes[i].transform.position = new Vector3(Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x), Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y),
                                                        Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z));
                Boxes[i].transform.rotation = Quaternion.identity;
                return;
            }
        }
    }

    private void BoxDestroyedAsADispatcher(Box b)
    {
        b.gameObject.SetActive(false);
    }

    private void SpawnWeapons(Box b)
    {
        Instantiate(WeaponPrefab, b.transform.position, Quaternion.identity);
    }
}
