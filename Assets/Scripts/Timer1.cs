using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer1 : MonoBehaviour
{
    // timer
    private float timer = 30;
    public Text timerTxt;
    private bool area = false;

    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "door1"){
            area = true;
            Debug.Log("timer started");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (area == true){
            startTimer();
        }
    }

    // timer that counts down once youve entered the outside area
    // if it hits 0 you die and the level resets
    public void startTimer(){
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
}