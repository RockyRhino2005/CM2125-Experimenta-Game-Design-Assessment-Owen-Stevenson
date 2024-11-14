using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 0.5f;
    public float Life = 0.5f;
    private Rigidbody2D myRigid;

    // Start is called before the first frame update
    void Start()
    {  

        Destroy(this.gameObject, Life);
        
    }
    void Update()
    {  

        myRigid = this.GetComponent<Rigidbody2D>();
        myRigid.AddForce(Vector3.right*3);
        
    }

    // when the attack hits the breakable wall it breaks
    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag =="wall" || collision.gameObject.tag =="enemy"){
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
