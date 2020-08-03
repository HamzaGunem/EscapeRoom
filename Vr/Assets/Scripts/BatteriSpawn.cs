using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriSpawn : MonoBehaviour
{
    public Transform BatteriSpawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Batteri"))
        {
            other.transform.position = BatteriSpawnPoint.transform.position;
        }
    }
}
