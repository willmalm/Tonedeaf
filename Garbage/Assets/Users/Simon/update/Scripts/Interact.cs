using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {

    public GameObject textBox;
    public int distance;


    ObjectVariables objectVar;
    Text txt;
    RaycastHit2D hit;


    void Start () {
        txt = textBox.GetComponent<Text>();
        objectVar = GetComponent<ObjectVariables>();
	}

	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(distance, 0), Vector2.right, distance);

        Debug.DrawLine(transform.position - new Vector3(distance, 0, 0), transform.position + new Vector3(distance, 0, 0));

        if (hit.collider.tag == "Player")
        {
            txt.text = "Pick up " + objectVar.objName;

            if (Input.GetKey("p"))
            {
                Debug.Log("Picked up " + objectVar.objName);
            }
        }
        else
        {
            txt.text = "";
        }
	}
}

