using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : XRBaseInteractable
{

    float yMax = 0.0f;
    float yMin = 0.0f;
    //Check the hight for the hand.
    float PreviousHandHight = 0.0f;
    private XRBaseInteractor HoverInteractor = null;

    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(StartPress);
        onHoverExit.AddListener(EndPress);

    }

    private void Start()
    {
        //Get the colider on the button
    }

    private void OnDestroy()
    {
        onHoverEnter.RemoveListener(StartPress);
        onHoverExit.RemoveListener(EndPress);
    }
    //Add interactor so the button knows what hand is interacting with it 
    private void StartPress(XRBaseInteractor interactor)
    {
        HoverInteractor = interactor;
        PreviousHandHight = interactor.transform.position.y;
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        HoverInteractor = null;
        PreviousHandHight = 0.0f;
    }
    private void SetMinMaxValue()
    {
        Collider collider = GetComponent<Collider>();
        //Get the actual hight of the button using the collider
        yMin = transform.position.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.position.y;
    }

}
