using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // timer
    public float timer = 30;
    public Text timerTxt;
    private bool area = false;
    public GameObject square;

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject == square){
            area = true;
            Debug.Log("Entered Area");
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
        timer -= Time.fixedDeltaTime * 1;
        timerTxt.text = (timer).ToString("0");
        if(timer < 0){
            Debug.Log("The Timer Exploded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
