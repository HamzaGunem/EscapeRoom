using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : XRBaseInteractable
{
    public UnityEvent OnPress = null;
    float yMax = 0.0f;
    float yMin = 0.0f;
    private bool PreviousPress = false;
    //Check the hight for the hand.
    float PreviousHandHight = 0.0f;
    private XRBaseInteractor HoverInteractor = null;
    public Vector3 NewPosition;

    public float StartTimeBtwClick =10f;
    public float TimeBtwClick;
    public bool isClicked;
    public bool isOnCd;
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(StartPress);
        onHoverExit.AddListener(EndPress);
    }

    private void Start()
    {
        SetMinMaxValue();
        isClicked = false;
        isOnCd = false;
    }

    private void OnDestroy()
    {
        onHoverEnter.RemoveListener(StartPress);
        onHoverExit.RemoveListener(EndPress);
    }
    //Add interactor so the button knows what hand is interacting with it 
    private void StartPress(XRBaseInteractor interactor)
    {
        if (isClicked == false)
        {
            HoverInteractor = interactor;
            PreviousHandHight = GetLocalYPosition(HoverInteractor.transform.position);
        }
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        HoverInteractor = null;
        PreviousHandHight = 0.0f;
        PreviousPress = false;
        SetYPosition(yMax);
        isClicked = true;
    }

    public void Update()
    {
        if(NewPosition.y == yMin)
        {
            HoverInteractor = null;
            isClicked = true;
        }
        if(isClicked == true && isOnCd == false) 
        {
            TimeBtwClick = StartTimeBtwClick;
            isOnCd = true;
        }
        if(TimeBtwClick <= 0)
        {
            isClicked = false;
            isOnCd = false;
        }

        TimeBtwClick -= Time.deltaTime;
        
        Debug.Log(NewPosition.y);
    }

    public void SetMinMaxValue()
    {
        Collider collider = GetComponent<Collider>();
        //Get the actual hight of the button using the collider
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.localPosition.y;
    }

    //When the object is going to be tracked 
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (HoverInteractor)
        {
            float newHandHight = GetLocalYPosition(HoverInteractor.transform.position);
            float HandDifference = PreviousHandHight - newHandHight;
            PreviousHandHight = newHandHight;

            float newPosition = transform.localPosition.y - HandDifference;
            SetYPosition(newPosition);

            CheckIfPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        //Take the position and convert it to localposition
        Vector3 localPosition = transform.root.InverseTransformPoint(position);
        return localPosition.y;
    }

    private void CheckIfPress()
    {
        bool inposition = InPosition();

        if (inposition && inposition != PreviousPress)
        {
            OnPress.Invoke();

            PreviousPress = inposition;
        }
    }
    //Set the new position
    public void SetYPosition(float position)
    {
        NewPosition = transform.localPosition;
        NewPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = NewPosition;
    }

    private bool InPosition()
    {
        //If the value is in the range it will be true else it will be false.
        float InRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);
        return transform.localPosition.y == InRange;
    }

}
