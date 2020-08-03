using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timmer : MonoBehaviour
{
    public Text Counter;
    private TimeSpan TimeOn;        //Allow to format the time
    private bool TimerGoing;
    //Call the script in another class
    public static Timmer instance;

    public float elapsedTime;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Counter.text = "Time: 05:00.00";
        TimerGoing = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        TimerGoing = true;
        elapsedTime = 10f;

        StartCoroutine(UpdateTimer());
    }

    private void Update()
    {
        if(elapsedTime <= 0f)
        {
            EndTimer();
        }
    }

    private void EndTimer()
    {
        TimerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (TimerGoing)
        {
            elapsedTime -= Time.deltaTime;
            TimeOn = TimeSpan.FromSeconds(elapsedTime);
            string TimeOnString = "Time" + TimeOn.ToString("mm':'ss'.'ff");
            Counter.text = TimeOnString;

            yield return null;
        }
    }
}
