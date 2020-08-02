using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale3 : MonoBehaviour
{
    public static float WeightToShow3 = 0f;
    public ObjectsWeights objectsweights;

    public void OnTriggerEnter(Collider scl3)
    {

        if (scl3.gameObject.tag.Equals("Watch"))
        {
            WeightToShow3 += objectsweights.WatchWeight;
        }
        if (scl3.gameObject.tag.Equals("Book"))
        {
            WeightToShow3 += objectsweights.BookWeight;
        }
        if (scl3.gameObject.tag.Equals("Phone"))
        {
            WeightToShow3 += objectsweights.PhoneWeight;
        }

    }

    public void OnTriggerExit(Collider scl3)
    {
        if (scl3.gameObject.tag.Equals("Watch"))
        {
            WeightToShow3 -= objectsweights.WatchWeight;
        }
        if (scl3.gameObject.tag.Equals("Book"))
        {
            WeightToShow3 -= objectsweights.BookWeight;
        }
        if (scl3.gameObject.tag.Equals("Phone"))
        {
            WeightToShow3 -= objectsweights.PhoneWeight;
        }
    }
}
