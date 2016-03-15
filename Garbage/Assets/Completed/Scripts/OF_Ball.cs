using UnityEngine;
using System.Collections;

public class OF_Ball : MonoBehaviour {

    public float speed;
    public float height;
    GameObject player;
    ObjectVariables var;
    Rigidbody2D rgd;

    Vector3 org;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        var = GetComponent<ObjectVariables>();
        rgd = GetComponent<Rigidbody2D>();
        org = transform.position;

	}

    // Update is called once per frame
    void Update() {
        if (var.used)
        {
            if(transform.position.y > org.y + height)
            {
                transform.Translate(Vector3.right * speed *Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * speed *Time.deltaTime);
            }
        }
    }
}
