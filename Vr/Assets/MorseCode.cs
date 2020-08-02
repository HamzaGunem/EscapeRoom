using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCode : MonoBehaviour
{
    private float StartTime = 0f; //Runtime
    private bool Changer = false; //Long or short click
    public float HoldTime = 0.5f; //Time for short click to become long
    public List<bool> morse = new List<bool>(); //Morse inputs
    private int puzzle = 0;
    private bool[] check; //puzzle arrays
    public int Inputs;

    public AudioClip MorseShort1;
    public AudioClip MorseShort2;
    public AudioClip MorseLong1;
    public AudioClip MorseLong2;
    public AudioClip WrongCode;
    public AudioClip RightCode;
    public AudioClip ResetAudio;

    //False = Dot, True = Dash
    public bool[] check1 = new bool[] { false, true, true, true, true,
                                        true, true, true, false, false,
                                        false, false, false, false, false,
                                        true, false, false, false, false};
                                        
    public bool[] check2 = new bool[] { true, true, true, true, true,
                                        true, false, false, false, false};
    public bool[] check3 = new bool[] {false, true, true, true, true,
                                       false, false, false, true, true};

    //Lights
    public Light[] Lights = new Light[3];
    // Start is called before the first frame update
    void Start()
    {
        Inputs = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //Call reset function
         if (Input.GetKey(KeyCode.LeftShift))
        {
            Reset();
            SoundManager.instance.PlayAudio(ResetAudio);
            SoundManager.instance.musicScource.Stop();
        }
        TurnLightsOn();
        //Check if players click is long or short
        if (Input.GetKey(KeyCode.Space))
        {

            StartTime += Time.deltaTime;
            Changer = false;
            SoundManager.instance.RandomSound(MorseShort1, MorseShort2);
            if (StartTime > HoldTime)
            {
                Changer = true;
                SoundManager.instance.RandomSound(MorseLong1, MorseLong2);
            }

        }
        //When the button is released add players input to the list.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartTime = 0f;
            morse.Add(Changer);

            if (morse.Count == Inputs) //If full
            {
                if (CheckMatch() == true ) 
                {
                    puzzle++;
                    Inputs = 10;
                    Debug.Log("Its True");
                }
                else 
                {
                    Debug.Log("Its False");
                }
                morse.Clear();
            }
        }
    }
    //Puzzle check
    bool CheckMatch()
    {
        bool[] morsebool = morse.ToArray(); //transfer the list to an array
        if (morsebool.Length != check.Length)
            return false;
        //Check the contents 
        for (int i = 0; i < morse.Count; i++)
        {
            if (morse[i] != check[i])
            return false;
            SoundManager.instance.RandomSound(WrongCode);
        }
        SoundManager.instance.RandomSound(RightCode);
        return true; //correct
    }

    public void TurnLightsOn()
    {
        //Choose which puzzle to check and turn lights on
        if (puzzle == 0)
        {
            check = check1;
        }
        else if (puzzle == 1)
        {
            Lights[0].enabled = true;
            Inputs = 10;
            check = check2;

        }
        else if (puzzle == 2)
        {
            Lights[1].enabled = true;
            check = check3;
        }
        else if (puzzle == 3)
        {
            Lights[2].enabled = true;
        }
    }

    public void Reset()
    {
        morse.Clear();
    }
}
