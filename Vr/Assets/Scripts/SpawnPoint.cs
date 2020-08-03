using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsFull;

    public void Start()
    {
        IsFull = false;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Book"))
        {
            IsFull = true;
        }
        else
        {
            IsFull = false;
        }
    }

}
