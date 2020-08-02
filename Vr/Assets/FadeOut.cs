using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    //Animator Reference
    public Animator _anim;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Walls"))
        {
            //Run The Animation
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Walls"))
        {
            //Run FadeOut animation
        }
    }
}
