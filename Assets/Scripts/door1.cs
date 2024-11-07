using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }
    // when player touches the door they are transported to the next section
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "door1"){
            UnityEngine.Debug.Log("changed location");
            transform.position=new Vector3(transform.position.x-200,transform.position.y-100, transform.position.z); 
        }

    }
}
