using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Interaction : MonoBehaviour {

    //Public variables
    public GameObject textBox;
    public GameObject itemUI;
    [Space(5)]
    public int distance;
    [Header("Read-only")]
    public bool canPickup;

    //Objects
    private GameObject objInventory;
    private GameObject player;
    private GameObject obj;
    public List<GameObject> objectList;

    //Scripts
    private Inventory inventory;
    private GridVariables objGridVar;
    private GridVariables plGridVar;
    private PlayerVariables playerVar;
    private ObjectVariables objectVar;

    //Components
    private Text txt;

    public List<GameObject> backUpList;

    void Start()
    {
        //Dependency "TextBox"
        txt = textBox.GetComponent<Text>();
        //Dependency "Inventory"
        objInventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory = objInventory.GetComponent<Inventory>();
        //Dependency "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerVar = player.GetComponent<PlayerVariables>();
        //Dependency "ObjectVariables", "Player_GridVariables", "This_GridVariables"
        objectVar = transform.parent.gameObject.GetComponent<ObjectVariables>();
        objGridVar = transform.parent.gameObject.GetComponent<GridVariables>();
        plGridVar = player.GetComponent<GridVariables>();

        objectList = new List<GameObject>();
        backUpList = new List<GameObject>();
    }

    void Update() {
        //Adds item to inventory on keypress
        /*if (Input.GetKeyDown("p") && canPickup)
        {
            Debug.Log("Picked up " + objectVar.objName);

            var obj = (GameObject)Instantiate(itemUI, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            Destroy(transform.parent.gameObject);
        }*/
    }

    //Changes value of bool based on collision
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "objInteract")
        {
            objectList.Add(col.gameObject);
            backUpList.Add(col.gameObject);
            col.gameObject.transform.parent.gameObject.GetComponent<ObjectVariables>().highlight.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "objInteract")
        {
            objectList.Remove(col.gameObject);
            backUpList.Remove(col.gameObject);
            col.gameObject.transform.parent.gameObject.GetComponent<ObjectVariables>().highlight.SetActive(false);
        }
    }
    public void PickUp()
    {
        //Check which item is closest to the player
        while (1 < objectList.Count) {
            Debug.Log("searching...");
            for (int i = 0; i < objectList.Count; i++)
            {
                for (int j = 0; j < objectList.Count;)
                {
                    if (j != i)
                    {
                        if (Vector2.Distance(player.transform.position, objectList[j].transform.position) > Vector2.Distance(player.transform.position, objectList[i].transform.position))
                        {
                            objectList.Remove(objectList[j]);
                            Debug.Log("Removed object j" + j);
                            j++;
                        }
                        else
                        {
                            objectList.Remove(objectList[i]);
                            Debug.Log("Removed object i" + i);
                            j = 1000000;
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }
        if (objectList.Count > 0)
        {
            //Add item to inventory and destroy object
            var obj = (GameObject)Instantiate(objectList[0].transform.parent.GetComponent<ObjectVariables>().inventoryItem, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            GameObject singleObject = objectList[0];
            backUpList.Remove(singleObject);
            Destroy(singleObject.transform.parent.gameObject);
            objectList = backUpList;
            //objectList.Clear();
            //objectList = backUpList;
        }
    }
}
