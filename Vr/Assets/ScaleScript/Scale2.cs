using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale2 : MonoBehaviour
{
    public static float WeightToShow2 = 0f;
    public ObjectsWeights objectsweights;


    public Scale Ref;
    public bool AbleToClick;
    private void Update()
    {
        AbleToClick = Ref.AbleToClick;
    }

    public void OnTriggerEnter(Collider scl2)
    {

        if (scl2.gameObject.tag.Equals("Watch"))
        {
            WeightToShow2 += objectsweights.WatchWeight;
        }
        if (scl2.gameObject.tag.Equals("Book"))
        {
            WeightToShow2 += objectsweights.BookWeight;
        }
        if (scl2.gameObject.tag.Equals("Phone"))
        {
            WeightToShow2 += objectsweights.PhoneWeight;
        }

    }

    public void OnTriggerExit(Collider scl2)
    {
        if (scl2.gameObject.tag.Equals("Watch"))
        {
            WeightToShow2 -= objectsweights.WatchWeight;
        }
        if (scl2.gameObject.tag.Equals("Book"))
        {
            WeightToShow2 -= objectsweights.BookWeight;
        }
        if (scl2.gameObject.tag.Equals("Phone"))
        {
            WeightToShow2 -= objectsweights.PhoneWeight;
        }
    }
}
