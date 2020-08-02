using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint1 : MonoBehaviour
{
    public bool IsFull1;

    public void Start()
    {
        IsFull1 = false;
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("Book"))
        {
            IsFull1 = true;
        }
        else
        {
            IsFull1 = false;
        }
    }
}
