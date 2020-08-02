using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicScource;
    public static SoundManager instance = null;

    //Change the pitch for the sound
    public float lowPitch = 0.95f;
    public float HightPitch = 1.05f;

    void Awake()
    {
        //Check if we got already a sound manager so we dont have 2 copies of it 
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayAudio (AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }
    //Make a function which take an array, params make it take few arguments
    public void RandomSound(params AudioClip[] clips)
    {
        //Make random pitch for the sound
        int randomIndex = Random.Range(0, clips.Length);
        float RandomPitch = Random.Range(lowPitch, HightPitch);
        effectSource.pitch = RandomPitch;
        effectSource.clip = clips[randomIndex];
        effectSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
