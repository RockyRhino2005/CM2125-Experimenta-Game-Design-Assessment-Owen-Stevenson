using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public float min=2f;
	public float max=3f;

    // Start is called before the first frame update
    void Start()
    {

        // positions platform pings between
        min=transform.position.x-28;
		max=transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {

        // makes platform move back and forth between original place and original place + 40
        transform.position = new Vector3(Mathf.PingPong(Time.time*4,max-min)+min, transform.position.y, transform.position.z);

        }
       
    }