using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script contains door mechanics
// script contains day cycle mechanics
// script contains timer mechanics
public class Door1 : MonoBehaviour
{
    // time
    public float seconds;
    public float minutes;
    public float hours;
    public float days;

    // timer
    private float timer = 60;
    private bool area = false;

    // day cycle
    public float cycle;
    private bool startDay;

    void FixedUpdate(){
        if (startDay == true){
            CalcTime();
        }

        if (area == true){
            StartTimer();
        }
    }

    public void CalcTime(){

        // in game day seconds
        seconds += Time.fixedDeltaTime * 1500;
        // timer for the player

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
            ChangeTime();
        }

        if(hours == 11.0){
            cycle = 3;
            hours += 1;
            ChangeTime();
        }

        if(hours == 17.0){
            cycle = 1;
            hours += 1;
            ChangeTime();
        }

        // resets hours every 24 and updates days accordingly
        if (hours >= 24){
            hours = 0;
            days += 1;
            Debug.Log("Day Passed");
        }


    }

    // when player touches the door they are transported to the next section
    public void OnCollisionEnter2D(Collision2D collision){
        // first door section
        if (collision.gameObject.CompareTag("door1")){
            Debug.Log("changed location");
            transform.position=new Vector3(transform.position.x-310,transform.position.y-60, transform.position.z);
            startDay = true;
            area = true;
            Debug.Log("timer started");
            Debug.Log("daylight cycle Started");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){

        // door 2
        // ends timer
        if (collision.gameObject.CompareTag("door2")){
            Debug.Log("changed location");
            startDay = false;
            area = false;
            Debug.Log("You outran the clock");

            if (cycle == 2){
                transform.position=new Vector3(transform.position.x,transform.position.y-280, transform.position.z);
            }
            // teleport to afternoon
            if (cycle == 3){
                transform.position=new Vector3(transform.position.x,transform.position.y-240, transform.position.z);
            } 
            // teleport to night
            else if (cycle == 1) {
                transform.position=new Vector3(transform.position.x,transform.position.y-200, transform.position.z);
            }
        }

    }

    // timer that counts down once youve entered the outside area
    // if it hits 0 you die and the level resets
    public void StartTimer(){
        // decreases timer each second
        timer -= (Time.deltaTime);
        // displays timer to debug log
        Debug.Log(timer);

        // after 30 seconds timer explodes and you die
        if(timer < 0){
            Debug.Log("The Timer Exploded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ChangeTime(){
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
