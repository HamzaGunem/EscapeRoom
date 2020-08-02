using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    public GameObject[] Light1;
    public GameObject[] Lights2;
    public GameObject[] Shadows;
    public float countDown;
    public float DicLight = 0.1f;
    public Timmer CountDown;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countDown = CountDown.elapsedTime;

        if (countDown <= 0)
        {
            TurnOnHissLight();
        }

        if (countDown > 0)
        {
            TurnOffHissLight();
        }
    }

    public void TurnOnHissLight()
    {
        foreach (GameObject GoThrowLight1 in Lights2)
        {
            Light light2 = GoThrowLight1.GetComponent<Light>();

            if (light2 != null && light2.intensity <= 1)
            {
                light2.intensity += DicLight * Time.deltaTime;
            }

        }
        foreach (GameObject GoThrowLight2 in Light1)
        {
            Light light1 = GoThrowLight2.GetComponent<Light>();

            if (light1 != null && light1.intensity >= 0)
            {
                light1.intensity -= DicLight * Time.deltaTime;
            }
        }

        foreach (GameObject GoThrowShadow in Shadows)
        {
            Light shadow = GoThrowShadow.GetComponent<Light>();

            if(shadow != null && shadow.intensity >= 0)
            {
                shadow.intensity -= DicLight * Time.deltaTime;
            }
        }

    }

    public void TurnOffHissLight()
    {
        foreach (GameObject GoThrowLight1 in Lights2)
        {
            Light light2 = GoThrowLight1.GetComponent<Light>();

            if (light2 != null && light2.intensity >= 0)
            {
                light2.intensity -= DicLight * Time.deltaTime;
            }
        }

        foreach (GameObject GoThrowLigh2 in Light1)
        {
            Light light1 = GoThrowLigh2.GetComponent<Light>();

            if (light1 != null && light1.intensity <= 10)
            {
                light1.intensity += DicLight * Time.deltaTime;
            }
        }

       
        foreach(GameObject GoThrowShadow in Shadows)
        {
            Light shadow = GoThrowShadow.GetComponent<Light>();

            if(shadow != null && shadow.intensity <= 5)
            {
                shadow.intensity += DicLight * Time.deltaTime;
            }
        }

    }
}