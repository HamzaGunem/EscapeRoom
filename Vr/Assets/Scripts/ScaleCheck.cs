using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCheck : MonoBehaviour
{
    public bool AbleToClick;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ("Watch") ||
            other.gameObject.tag == ("Phone"))
        {
            AbleToClick = true;
        }else if(other.gameObject.tag !=("Watch") &&
            other.gameObject.tag != ("Phone"))
        {
            AbleToClick = false;
        }
    }
}
