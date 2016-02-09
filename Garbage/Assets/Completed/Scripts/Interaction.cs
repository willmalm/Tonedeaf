using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour {

    //Public variables
    public GameObject textBox;
    public GameObject itemUI;
    [Space(5)]
    public int distance;
    [Header("Read-only")]
    public bool canPickup;

    //Objects
    private GameObject invObject;
    private GameObject player;

    //Scripts
    private Inventory inventory;
    private GridVariables objGridVar;
    private GridVariables plGridVar;
    private PlayerVariables playerVar;
    private ObjectVariables objectVar;

    //Components
    private Text txt;

    //Misc.
    private RaycastHit2D hit;

    void Start()
    {
        //Dependancy "TextBox"
        txt = textBox.GetComponent<Text>();
        //Dependancy "Inventory"
        invObject = GameObject.FindGameObjectWithTag("Inventory");
        inventory = invObject.GetComponent<Inventory>();
        //Dependancy "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerVar = player.GetComponent<PlayerVariables>();
        //Dependancy "ObjectVariables", "Player_GridVariables", "This_GridVariables"
        objectVar = transform.parent.gameObject.GetComponent<ObjectVariables>();
        objGridVar = transform.parent.gameObject.GetComponent<GridVariables>();
        plGridVar = player.GetComponent<GridVariables>();
    }

    void Update() {
        //Adds item to inventory on keypress
        if (Input.GetKeyDown("p") && canPickup)
        {
            Debug.Log("Picked up " + objectVar.objName);

            var obj = (GameObject)Instantiate(itemUI, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            Destroy(transform.parent.gameObject);
        }
    }

    //Changes value of bool based on collision
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "plInteract" && objGridVar.gridLayer == plGridVar.gridLayer)
        {
            canPickup = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plInteract" && objGridVar.gridLayer == plGridVar.gridLayer)
        {
            txt.text = "Pick up " + objectVar.objName;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "plInteract")
        {
            txt.text = "";
        }
    }
}
