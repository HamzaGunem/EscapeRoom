using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public SpawnPoint Ref;
    public SpawnPoint1 Ref1;
    public bool IsFullRef;
    public bool IsFUllRef1;

    public Transform Position;
    public Transform Position1;
    public void Update()
    {
        IsFullRef = Ref.IsFull;
        IsFUllRef1 = Ref1.IsFull1;
    }

    public void OnColliderEnter(Collision other)
    {
        if (other.gameObject.tag != ("Batteri") && IsFullRef == false)
        {
            other.transform.position = Position.transform.position;
        }
        else if (other.gameObject.tag != ("Batteri") && IsFullRef == true)
        {
            other.transform.position = Position1.transform.position;
        }
    }
}
