using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CatMove : MonoBehaviour {
    public string up;
    public string left;
    public string right;
    public string run;
    public string hide;
    public float lastJumped;
    private bool isGrounded;
    private Rigidbody2D myRigid;
    private bool inFrontCupboard;
    // private bool hidden; 

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component.
        myRigid = this.GetComponent<Rigidbody2D>(); 
    }

    // when the cat is infront of a cupboard this statment
    // becomes true and allows the cat to hide
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag =="cupboard"){
            // Debug.log("colided");
            inFrontCupboard = true;
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
            this.transform.Translate(new Vector3(-5f, 0, 0)* Time.deltaTime * 1);
        }

        // right
        if (Input.GetKey(right)) {
            this.transform.Translate(new Vector3(5f, 0, 0)* Time.deltaTime * 1);
        }

        // run right
        if (Input.GetKey(run) && Input.GetKey(right)) {
            this.transform.Translate(new Vector3(15f, 0, 0)* Time.deltaTime * 1);
        }

        // run left
        if (Input.GetKey(run) && Input.GetKey(left)) {
            this.transform.Translate(new Vector3(-15f, 0, 0)* Time.deltaTime * 1);
        }

        // // hide
        // // testing if h is working
        // if (input.GetKey(hide)){
        //     Debug.log("h pressed");
        // }

        // // testing if statment
        // if (inFrontCupboard==true){
        //     Debug.log("its true");
        // }

        if (Input.GetKey(hide) && inFrontCupboard==true){
            // Debug.log("its true");
            this.transform.Translate(new Vector3(-100f, -100f, -100f)* Time.deltaTime * 1);
            // hidden = true;
            while(Input.GetKey(hide)==false){
                // hidden = false;
                inFrontCupboard = false;
                this.transform.Translate(new Vector3(-10f, 10f, 10f)* Time.deltaTime * 1);
            }
        }

    }

}
