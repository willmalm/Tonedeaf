using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public GameObject textBox;
    public int distance;

    RaycastHit2D hit;


    void Start () {
        hit = Physics2D.Raycast(transform.position, new Vector2(distance, 0));
	}

	void Update () {
        Debug.DrawLine(transform.position, transform.position + new Vector3(distance,0));

       /* if (hit)
        {
            if (hit.collider.tag == "obj")
            { 
            }
            if (hit.collider.tag == "obj" && Input.GetKey("p"))
            {

            }
        }*/
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "obj")
        {
            textBox.GetComponent<UnityEngine.UI.Text>().text = "Pick up " + col.gameObject.GetComponent<ObjectVariables>().objName;

            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Picked up " + col.gameObject.GetComponent<ObjectVariables>().objName);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "obj")
        {
            textBox.GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Picked up " + col.gameObject.GetComponent<ObjectVariables>().objName);
        }
    }
}
