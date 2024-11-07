using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Evolution : MonoBehaviour
{

    public GameObject Evolve_Token;
    private Rigidbody2D myRigid;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {

        // Get the Rigidbody component.
        myRigid = this.GetComponent<Rigidbody2D>(); 
        
    }

    // when the cat is interacts with evo token
    // becomes true and allows the cat to hide
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Evolve_Token){
            UnityEngine.Debug.Log("Evo Collided with");
            Destroy(collision.gameObject);
            // change sprite
            spriteRenderer.sprite = newSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
