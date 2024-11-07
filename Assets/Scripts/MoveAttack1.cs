using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    private Rigidbody2D myRigid;

    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();
        ps = GameObject.Find("destruction").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigid.AddForce(this.transform.right*25);
    }

    // when the attack hits the breakable wall it breaks
    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag =="wall"){
            Instantiate(ps,transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
            Destroy(this.gameObject);
    }
}