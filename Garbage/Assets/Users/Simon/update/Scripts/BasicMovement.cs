using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

    public float speed;
    public float jump;

    Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        if (Input.GetKey("left"))
        {
            rb2D.MovePosition(transform.position - transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            rb2D.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown("up"))
        {
            rb2D.MovePosition(transform.position + transform.up * jump * Time.deltaTime);
        }

    }
}
