using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    public float seconds;
    public float minutes;
    public float hours;
    public float days;

    public float cycle;

    private bool startDay;

    void FixedUpdate(){
        if (startDay == true){
            CalcTime();
        }


    }

    public void CalcTime(){

        seconds += Time.fixedDeltaTime * 1500;

        // resets seconds every 60 ingame and updates minutes accordingly
        if (seconds >= 60){
            seconds = 0;
            minutes += 1;
            // Debug.Log("Minute Passed");
        }

        // resets minutes every 60 ingame and updates hours accordingly
        if (minutes >= 60){
            minutes = 0;
            hours += 1;
            Debug.Log("Hour Passed");
        }

        // changes background depending on after each 8 hours
        if(hours == 5.0){
            cycle = 2;
            hours += 1;
            changeTime();
        }

        if(hours == 11.0){
            cycle = 3;
            hours += 1;
            changeTime();
        }

        if(hours == 17.0){
            cycle = 1;
            hours += 1;
            changeTime();
        }

        // resets hours every 24 and updates days accordingly
        if (hours >= 24){
            hours = 0;
            days += 1;
            Debug.Log("Day Passed");
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // when player touches the door they are transported to the next section
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "door1"){
            UnityEngine.Debug.Log("changed location");
            transform.position=new Vector3(transform.position.x-310,transform.position.y-60, transform.position.z);
            startDay = true;
            Debug.Log("daylight cycle Started");
        }

    }

    public void changeTime(){
        // teleport to day
        if (cycle == 2){

            transform.position=new Vector3(transform.position.x,transform.position.y-40, transform.position.z);
        }
        // teleport to afternoon
        if (cycle == 3){
            transform.position=new Vector3(transform.position.x,transform.position.y-40, transform.position.z);
        } 
        // teleport to night
        else if (cycle == 1) {
            transform.position=new Vector3(transform.position.x,transform.position.y+100, transform.position.z);
        }
    }
}
