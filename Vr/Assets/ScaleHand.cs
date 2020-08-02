using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHand : MonoBehaviour
{
    public Scale Ref;
    public float MaxWeight = 100f;
    public float percent;
    public float FinalPercent;
    public float Weight;
    public float turningRate = 30f;

    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.identity;
    // Call this when you want to turn the object smoothly.
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
    }

    private void Update()
    {
        Weight = Ref.FinalWeight;
        percent = Weight / MaxWeight;
        FinalPercent = 360 * percent;
        // Turn towards our target rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
    }
}
