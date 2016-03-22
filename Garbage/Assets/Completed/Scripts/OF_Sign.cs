using UnityEngine;
using System.Collections;

public class OF_Sign : MonoBehaviour {
    public float accel;
    public float orgSpeed;
    public float speed;
    public float min;
    public float max;
    int direction = 1;
    bool swinging;
    ObjectVariables var;
    GameObject player;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            swinging = false;
            speed += accel * Time.deltaTime;
            if(speed >= orgSpeed)
            {
                speed = orgSpeed;
            }
            var.force = 0;
            var.used = false;
        }
        else
        {
            swinging = true;
            speed -= accel * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
        if (swinging)
        {
            if (transform.eulerAngles.z >= max && transform.eulerAngles.z < min)
            {
                direction = -1;
            }
            else if (transform.eulerAngles.z >= min)
            {
                direction = 1;
            }
            transform.eulerAngles += new Vector3(0, 0, direction * speed * Time.deltaTime);
        }
        else
        {
            if(transform.position.x < player.transform.position.x)
            {
                transform.eulerAngles += new Vector3(0, 0, 1 * speed * Time.deltaTime);
                if (transform.eulerAngles.z >= max)
                {
                    transform.eulerAngles = new Vector3(0, 0, max);
                }
            }
            else if (transform.position.x > player.transform.position.x)
            {
                transform.eulerAngles += new Vector3(0, 0, -1 * speed * Time.deltaTime);
                if (transform.eulerAngles.z <= min && transform.eulerAngles.z >= max)
                {
                    transform.eulerAngles = new Vector3(0, 0, min);
                }
            }
        }
    }
}
