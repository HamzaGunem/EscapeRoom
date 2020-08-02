using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriHolder : MonoBehaviour
{
    public float timer;
    public Timmer timRef;
    public GameObject BatteriRef;
    public GameObject Hands;
    private void Start()
    {
    }
    public void Update()
    {
        BatteriRef = GameObject.FindGameObjectWithTag("Batteri");
        Hands = GameObject.FindGameObjectWithTag("Hands");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Batteri"))
        {
            timRef.BeginTimer();
            timer = timRef.elapsedTime;
            Destroy(this.BatteriRef);
            DontDestroyOnLoad(Hands);
        }
    }
}
