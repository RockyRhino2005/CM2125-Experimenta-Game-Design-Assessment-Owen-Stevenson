using UnityEngine;

public class Dog : MonoBehaviour
{
    
    public float min=2f;
	public float max=3f;

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
        transform.position =new Vector3(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y, transform.position.z);

        }
       
    }

