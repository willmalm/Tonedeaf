using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    GameObject player;
    public int smoothSpeed;
    public float limitLeft;
    public float limitRight;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y, -100);

        if(transform.position.x <= limitLeft)
        {
            transform.position = new Vector3(limitLeft, transform.position.y, transform.position.z);
        }
        else if(transform.position.x >= limitRight)
        {
            transform.position = new Vector3(limitRight, transform.position.y, transform.position.z);
        }
    }
}
