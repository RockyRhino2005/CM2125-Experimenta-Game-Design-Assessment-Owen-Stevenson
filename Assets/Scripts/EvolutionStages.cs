using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Evolution : MonoBehaviour
{

    public GameObject Evolve_Token1;
    private Rigidbody2D myRigid;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private bool evo1;
    public float lastAttack;
    public GameObject attack1;

    public String firstAttack;
    // Start is called before the first frame update
    void Start()
    {

        // Get the Rigidbody component.
        myRigid = this.GetComponent<Rigidbody2D>(); 
        
    }

    // when the cat is interacts with evo token
    // it destroys and changes the cats evo state
    // as well as its sprite
    // it now displays a particle system that lasts 3 seconds
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Evolve_Token1){
            UnityEngine.Debug.Log("Evo Collided with");
            Destroy(collision.gameObject);
            // change sprite
            spriteRenderer.sprite = newSprite;
            evo1 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // when the player presses f it does an attack depending on which evo state it is in
        GameObject tmpAttack;
        // evo1 attack
        if (Input.GetKey(firstAttack)) {
            if(evo1 == true){
                if(Time.time > lastAttack + 1){
                    Debug.Log("attack");
                    tmpAttack = Instantiate(attack1, this.transform.position + (this.transform.right), this.transform.rotation);
                    lastAttack = Time.time;
                }
            }
        }
        
    }
}
