using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    // for day/time display
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;

    public float seconds;
    public float minutes;
    public float hours;
    public float days;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate(){

        CalcTime();
        DisplayTime();
    }

    public void CalcTime(){

        seconds += Time.fixedDeltaTime * 1;

        // resets seconds every 60 ingame and updates minutes accordingly
        if (seconds >= 60){
            seconds = 0;
            minutes += 1;
            Debug.Log("Minute Passed");
        }

        // resets minutes every 60 ingame and updates hours accordingly
        if (seconds >= 60){
            minutes = 0;
            hours += 1;
            Debug.Log("Hour Passed");
        }

        // resets hours every 24 and updates days accordingly
        if (hours >= 24){
            hours = 0;
            days += 1;
            Debug.Log("Day Passed");
        }


    }

    public void DisplayTime(){
        // format makes there always be 0s so the text is never empty
        timeDisplay.text = string.Format("[0.00].[1.00]", hours, minutes); 
        dayDisplay.text = "Day: " + days;

    }
}
