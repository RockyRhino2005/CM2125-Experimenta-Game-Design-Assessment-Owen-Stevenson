using UnityEngine;
using UnityEngine.SceneManagement;
public class Projectile3 : MonoBehaviour
{

    public float speed = 4.5f;
    public float Life = 5f;
    private Rigidbody2D myRigid;

    public ParticleSystem ps;

    

    // Start is called before the first frame update
    void Start()
    {  

        Destroy(this.gameObject, Life);
        ps = GameObject.Find("confetti").GetComponent<ParticleSystem>();
        
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
            Instantiate(ps,transform.position, transform.rotation);
            Debug.Log("You Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
