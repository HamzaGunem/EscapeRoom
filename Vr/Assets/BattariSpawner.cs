using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattariSpawner : MonoBehaviour
{
    public GameObject[] Spawner;
    public float SpawnTimer;
    public Timmer TimeRef;
    public int BatteriinScene;

    public void Start()
    {
        SpawnTimer = TimeRef.elapsedTime;
        BatteriinScene = 0;
    }
    // Update is called once per frame
    void Update()
    {
        SpawnTimer = TimeRef.elapsedTime;

        if (SpawnTimer <= 0 && BatteriinScene == 0)
        {
            Instantiate(Spawner[0], transform.position, Quaternion.identity); 
            BatteriinScene += 1;
        }
        if (SpawnTimer > 8)
        {
            BatteriinScene = 0;
        }
    }

}
