using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour {

    public GameObject textBox;
    public int distance;
    GameObject invObject;
    Inventory inventory;
    public GameObject itemUI;
    bool canPickup;

    ObjectVariables objectVar;
    GridVariables objGridVar;
    GridVariables plGridVar;
    Text txt;
    RaycastHit2D hit;
    GameObject player;
    PlayerVariables playerVar;


    void Start()
    {
        txt = textBox.GetComponent<Text>();
        objectVar = transform.parent.gameObject.GetComponent<ObjectVariables>();
        invObject = GameObject.FindGameObjectWithTag("Inventory");
        inventory = invObject.GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerVar = player.GetComponent<PlayerVariables>();
        objGridVar = transform.parent.gameObject.GetComponent<GridVariables>();
        plGridVar = player.GetComponent<GridVariables>();
    }

    void Update() {
        if (Input.GetKeyDown("p") && canPickup)
        {
            Debug.Log("Picked up " + objectVar.objName);
            var obj = (GameObject)Instantiate(itemUI, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            Destroy(transform.parent.gameObject);
        }
    }

  
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "plInteract")
        {
            txt.text = "";
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plInteract" && objGridVar.gridLayer == plGridVar.gridLayer)
        {
            txt.text = "Pick up " + objectVar.objName;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "plInteract" && objGridVar.gridLayer == plGridVar.gridLayer)
        {
            canPickup = true;
        }
    }
}
