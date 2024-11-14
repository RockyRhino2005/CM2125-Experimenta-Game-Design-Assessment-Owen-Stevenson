using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Evolution : MonoBehaviour
{

    public GameObject Evolve_Token1;
    public GameObject Evolve_Token2;
    public GameObject Evolve_Token3;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite2;
    public Sprite newSprite3;
    private bool evo1;
    private bool evo2;
    private bool evo3;
    public float lastAttack;


    // projectiles
    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public String firstAttack;
    private Rigidbody2D myRigid;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {

        // Get the Rigidbody component.
        myRigid = this.GetComponent<Rigidbody2D>(); 
        ps = GameObject.Find("confetti").GetComponent<ParticleSystem>();
    }

    // when the cat is interacts with evo token
    // it destroys and changes the cats evo state
    // as well as its sprite
    // it now displays a particle system that lasts 3 seconds
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Evolve_Token1){
            Debug.Log("Evo Collided with");
            Destroy(collision.gameObject);
            // change sprite
            spriteRenderer.sprite = newSprite;
            evo1 = true;
            evo2 = false;
            evo3 = false;
        }
        else if (collision.gameObject == Evolve_Token2){
            Debug.Log("Evo Collided with");
            Destroy(collision.gameObject);
            // change sprite
            spriteRenderer.sprite = newSprite2;
            evo1 = false;
            evo2 = true;
            evo3 = false;
        }
        else if (collision.gameObject == Evolve_Token3){
            Destroy(collision.gameObject);
            // change sprite
            spriteRenderer.sprite = newSprite3;
            evo1 = false;
            evo2 = false;
            evo3 = true;
            Instantiate(ps,transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // when the player presses f it does an attack depending on which evo state it is in
        // evo1 attack
        if (Input.GetKey(firstAttack)) {
            // ninja kick
            if(evo1 == true){
                if(Time.time > lastAttack + 1){
                    Debug.Log("attack");
                    Instantiate(projectile1, transform.position, transform.rotation);
                    lastAttack = Time.time;
                }
            }
            // gun
            if(evo2 == true){
                if(Time.time > lastAttack + 1){
                    Debug.Log("shot");
                    Instantiate(projectile2, this.transform.position + this.transform.right, this.transform.rotation);
                    lastAttack = Time.time;
                }
            }
            // plasma
            if(evo3 == true){
                if(Time.time > lastAttack + 1){
                    Debug.Log("Mind Attack");
                    Instantiate(projectile3, this.transform.position + this.transform.right, this.transform.rotation);
                    lastAttack = Time.time;
                }
            }
        }
        
    }
}
