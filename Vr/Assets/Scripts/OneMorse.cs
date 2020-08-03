using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMorse : MonoBehaviour
{
    private float StartTime = 0f; //Time variable set at runtime
    private bool Changer = false; //bool to set the morse note is long or short
    public float HoldTime = 0.5f; //time until short note becomes long (default 0.5 seconds)
    public List<bool> morse = new List<bool>(); //list to add the morse note combination
    private int puzzle = 0; //so the script knows which puzzle it's on (default 1)
    private bool[] check; //empty array to hold the different puzzle arrays

    public int Inputs;
    //Puzzle    //False = Dot, True = Dash
    public bool[] check1 = new bool[] { false, true, true, true, true,
                                        true, true, true, false, false,
                                        false, false, false, false, false,
                                        true, false, false, false, false}; //first puzzle
                                        
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Restart();
        }
        TurnLightsOn();
        //determine weather the note will be long or short depending on how long the button is pressed
        if (Input.GetKey(KeyCode.Space))
        {

            StartTime += Time.deltaTime;
            Changer = false;
            if (StartTime > HoldTime)
            {
                Changer = true;
            }

        }
        //when the button is released add the last note to the end of the list. if the list is full check if it matches the selected puzzle 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartTime = 0f; //reset time
            morse.Add(Changer); //add note


            if (morse.Count == Inputs) //if full
            {
                if (CheckMatch() == true ) //check if it's correct
                {
                    puzzle++; //if correct move to the next puzzle
                    Debug.Log("yaay");
                    Inputs = 10;
                }
                else //if not correct
                {
                    Debug.Log("nay");
                }
                morse.Clear(); //clear list
            }
        }
    }
    //check if the puzzle is correct
    bool CheckMatch()
    {
        bool[] morsebool = morse.ToArray(); //transfer the list content to an array for comparison between the different puzzles

      

        //check if it's the correct number of inputs (probably not needed.
        if (morsebool.Length != check.Length)
            return false;
        // check the contents compared to each other 
        for (int i = 0; i < morse.Count; i++)
        {
            if (morse[i] != check[i]) //if anything is wrong go back
                return false;
        }
        return true; //say it's correct
    }

    public void TurnLightsOn()
    {
        //choose which puzzle to check
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

    public void Restart()
    {
        morse.Clear();
    }
}
