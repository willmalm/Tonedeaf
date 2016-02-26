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
    private GameObject object_Inventory;
    private GameObject player;

    //Lists
    public List<GameObject> item_List;
    public List<GameObject> screech_List;

    private List<GameObject> backup_List;
    private List<ObjectVariables> var_List;

    //Scripts
    private Inventory inventory;

    //Components
    private Text txt;

    //Variables
    private bool screeching = false;

    void Start()
    {
        //Dependency "TextBox"
        txt = textBox.GetComponent<Text>();
        //Dependency "Inventory"
        object_Inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory = object_Inventory.GetComponent<Inventory>();
        //Dependency "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        item_List = new List<GameObject>();
        backup_List = new List<GameObject>();
        screech_List = new List<GameObject>();
        var_List = new List<ObjectVariables>();
    }

    void Update()
    {
        if (screeching)
        {
            for (int i = 0; i < screech_List.Count; i++)
            {
                var_List[i].force += Time.deltaTime;
            }
        }
    }

    //Changes value of bool based on collision
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "objInteract")
        {
            item_List.Add(col.gameObject);
            backup_List.Add(col.gameObject);
            col.gameObject.transform.parent.gameObject.GetComponent<ObjectVariables>().highlight.SetActive(true);
        }
        if (col.tag == "scrObject")
        {
            screech_List.Add(col.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "objInteract")
        {
            item_List.Remove(col.gameObject);
            backup_List.Remove(col.gameObject);
            col.gameObject.transform.parent.gameObject.GetComponent<ObjectVariables>().highlight.SetActive(false);
        }
        if(col.tag == "scrObject")
        {
            screech_List.Remove(col.gameObject);
        }
    }
    public void PickUp()
    {
        //Check which item is closest to the player
        while (1 < item_List.Count) {
            Debug.Log("searching...");
            for (int i = 0; i < item_List.Count; i++)
            {
                for (int j = 0; j < item_List.Count;)
                {
                    if (j != i)
                    {
                        if (Vector2.Distance(player.transform.position, item_List[j].transform.position) > Vector2.Distance(player.transform.position, item_List[i].transform.position))
                        {
                            item_List.Remove(item_List[j]);
                            Debug.Log("Removed object j" + j);
                            j++;
                        }
                        else
                        {
                            item_List.Remove(item_List[i]);
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
        if (item_List.Count > 0)
        {
            //Add item to inventory and destroy object
            var obj = (GameObject)Instantiate(item_List[0].transform.parent.GetComponent<ObjectVariables>().inventoryItem, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            GameObject singleObject = item_List[0];
            backup_List.Remove(singleObject);
            Destroy(singleObject.transform.parent.gameObject);
            item_List = backup_List;
        }
    }
    public void Screech()
    {
        for (int i = 0; i < screech_List.Count; i++)
        {
            var_List.Add(screech_List[i].GetComponent<ObjectVariables>());
        }       
        screeching = true;
    }
    public void ScreechStop()
    {
        var_List.Clear();
        screeching = false;
    }
}
