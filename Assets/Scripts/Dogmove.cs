using UnityEngine;

public class DogMove : MonoBehaviour
{
    
    public float min=2f;
	public float max=3f;

    private bool isFacingLeft = false;

    // Start is called before the first frame update
    void Start()
    {

        // positions dog pings between
        min=transform.position.x;
		max=transform.position.x+40;
        
    }

    // Update is called once per frame
    void Update()
    {

        // makes enemy move back and forth between original place and original place + 40
        // when the enemy starts moving right his image flips and vice versa
        float pinging = Mathf.PingPong(Time.time*8,max-min)+min;
        transform.position =new Vector3(pinging, transform.position.y, transform.position.z);

        if ((isFacingLeft == false && pinging > transform.position.x) || (isFacingLeft == true && pinging < transform.position.x)){
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

       
}

