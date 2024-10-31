using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CatMove : MonoBehaviour {
    public string up;
    public string left;
    public string right;
    public string run;
    public string hide;
    public float lastJumped;

    public GameObject cupboard;
    private Rigidbody2D myRigid;
    private bool inFrontCupboard;

    private bool isFacingRight;

    private bool hidden;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component.
        myRigid = this.GetComponent<Rigidbody2D>(); 

        isFacingRight = true;
    }

    // when the cat is infront of a cupboard this statment
    // becomes true and allows the cat to hide
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject == cupboard){
            inFrontCupboard = true;
            UnityEngine.Debug.Log("infrontcupboard");
        }
    }

    public void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject == cupboard){
            inFrontCupboard = false;
            hidden = false;
            UnityEngine.Debug.Log("left cupboard");
            Physics2D.IgnoreLayerCollision(6,7,false);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(up)) {
            // upward force but with if to stop flight
            if (Time.time > lastJumped + 2) 
            {
                myRigid.AddForce(new Vector2(0f, 20f),ForceMode2D.Impulse);
                lastJumped = Time.time;
            } 
        }

        // left
        if (Input.GetKey(left)) {
            this.transform.Translate(new Vector3(5f, 0, 0) * Time.deltaTime * 1);
            if (isFacingRight == true){
                this.transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = false;
            }
        }

        // right
        if (Input.GetKey(right)) {
            this.transform.Translate(new Vector3(5f, 0, 0)* Time.deltaTime * 1);
            if (isFacingRight == false){
                this.transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = true;
            }
        }

        // run right
        if (Input.GetKey(run) && Input.GetKey(right)) {
            this.transform.Translate(new Vector3(15f, 0, 0)* Time.deltaTime * 1);
            if (isFacingRight == false){
                this.transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = true;
            }
        }

        // run left
        if (Input.GetKey(run) && Input.GetKey(left)) {
            this.transform.Translate(new Vector3(15f, 0, 0)* Time.deltaTime * 1);
            if (isFacingRight == true){
                this.transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = false;
            }
        }

        // when pressing h and infrot of cupboard the character is hidden
        //until the player presses
        if (Input.GetKey(hide) && inFrontCupboard==true){
            UnityEngine.Debug.Log("key pressed and hidden");
            hidden = true;
            }

            if (hidden == true){
                UnityEngine.Debug.Log("Hidden is true");
                Physics2D.IgnoreLayerCollision(6,7,true);
            }

        }



    }


