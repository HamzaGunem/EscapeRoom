using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Scale : MonoBehaviour
{
    public Text WeightText;
    public float WeightToShow = 0f;
    public float FinalWeight = 0f;
    public float WeightToShow2;
    public float WeightToShow3;
    public float WeightToShow4;
    public ObjectsWeights objectsweights;
    public bool CanCal;

    //Ref
    public Button ButtonRef;
    public bool calc;
    public float IsOnCoolDown;

    public ScaleCheck CheckRef;
    public bool AbleToClick;

    public void Start()
    {
        CanCal = false;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        WeightText.text = FinalWeight.ToString();
    }

    public void Update()
    {
        calc = ButtonRef.isClicked;
        AbleToClick = CheckRef.AbleToClick;
        IsOnCoolDown = ButtonRef.TimeBtwClick;
        if (calc == true && IsOnCoolDown >= 9.74 && AbleToClick == true)
        {
            CanCal = true;
            WeightCalc();
        }

        if(IsOnCoolDown >= 0)
        {
            CanCal = false;
        }

        if(AbleToClick == false)
        {
            CanCal = false;
        }


    }
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag.Equals("Watch"))
        {
            WeightToShow += objectsweights.WatchWeight;
        }
        else if (other.gameObject.tag.Equals("Book"))
        {
            WeightToShow += objectsweights.BookWeight;
        }
      
        else if (other.gameObject.tag.Equals("Phone"))
        {
            WeightToShow += objectsweights.PhoneWeight;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Watch"))
        {
            WeightToShow -= objectsweights.WatchWeight;
        }
        if (other.gameObject.tag.Equals("Book"))
        {
            WeightToShow -= objectsweights.BookWeight;
        }
        if (other.gameObject.tag.Equals("Phone"))
        {
            WeightToShow -= objectsweights.PhoneWeight;
        }
    }

    public void WeightCalc()
    {
        if (CanCal == true)
        {
            WeightToShow2 = Scale2.WeightToShow2;
            WeightToShow3 = Scale3.WeightToShow3;
            WeightToShow4 = Scale4.WeightToShow4;
            FinalWeight = WeightToShow + WeightToShow2 + WeightToShow3 + WeightToShow4;
        }
    }
}
