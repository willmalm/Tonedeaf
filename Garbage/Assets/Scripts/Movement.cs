using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public PlayerVariables playerVar;

	void Start () {
	
	}

	void Update () {

        if (Input.GetKey("right") && playerVar.immobile == false)
        {
            transform.position += new Vector3(10 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey("left") && playerVar.immobile == false)
        {
            transform.position -= new Vector3(10 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, playerVar.speed / 4 * Time.deltaTime, 0);
        }
        if (Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, playerVar.speed / 4 * Time.deltaTime, 0);
        }
	}
}
