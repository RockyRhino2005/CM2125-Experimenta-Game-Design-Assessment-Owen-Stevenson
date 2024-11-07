using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoring : MonoBehaviour
{

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when colldiding with a cat box it adds to the score
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "score"){
            UnityEngine.Debug.Log("score increased");
            Destroy(collision.gameObject);
            adjustScore(1);
        }

    }

    public int getScore(){
        return score;
    }

    public void setScore(int s){
        score = s;
    }

    public void adjustScore(int s){
        score += s;
        Debug.Log("Score is " + score);
    }
}
