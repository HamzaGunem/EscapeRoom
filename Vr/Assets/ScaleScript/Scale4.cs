using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale4 : MonoBehaviour
{
    public static float WeightToShow4 = 0f;
    public ObjectsWeights objectsweights;

    public void OnTriggerEnter(Collider scl4)
    {

        if (scl4.gameObject.tag.Equals("Watch"))
        {
            WeightToShow4 += objectsweights.WatchWeight;
        }
        if (scl4.gameObject.tag.Equals("Book"))
        {
            WeightToShow4 += objectsweights.BookWeight;
        }
        if (scl4.gameObject.tag.Equals("Phone"))
        {
            WeightToShow4 += objectsweights.PhoneWeight;
        }

    }

    public void OnTriggerExit(Collider scl4)
    {
        if (scl4.gameObject.tag.Equals("Watch"))
        {
            WeightToShow4 -= objectsweights.WatchWeight;
        }
        if (scl4.gameObject.tag.Equals("Book"))
        {
            WeightToShow4 -= objectsweights.BookWeight;
        }
        if (scl4.gameObject.tag.Equals("Phone"))
        {
            WeightToShow4 -= objectsweights.PhoneWeight;
        }
    }
}
