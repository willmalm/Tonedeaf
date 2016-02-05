using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour {

    public GameObject textBox;
    public int distance;


    ObjectVariables objectVar;
    Text txt;
    RaycastHit2D hit;


    void Start()
    {
        txt = textBox.GetComponent<Text>();
        objectVar = GetComponent<ObjectVariables>();
    }

    void Update() { }

  
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "plInteract")
        {
            txt.text = "";
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plInteract")
        {
            txt.text = "Pick up " + objectVar.objName;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "plInteract")
        {
            if (Input.GetKeyDown("p"))
            {
                Debug.Log("Picked up " + objectVar.objName);
            }
        }
    }
}
