using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LightChange Ref;
    public float CountDown;

    // Update is called once per frame
    void Update()
    {
        CountDown = Ref.countDown;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") && CountDown <= 0)
        {
            //Close the door
        }
    }
}
