using UnityEngine;
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
    private GameObject cameraObject;

    //Lists
    public List<GameObject> list_pickup;  //List of type 0
    public List<GameObject> list_screech; //List of type 1
    public List<GameObject> list_event;   //List of type 2

    private List<GameObject> list_temp; //Temporary list of type 0
    private List<ObjectVariables> list_var1; //Variables of type 1


    //Scripts
    private Inventory inventory;
    private SpawnByLoudness micInput;
    private CameraMovement camMov;
    private PlayerController plController;

    //Variables
    private bool screeching = false;

    void Start()
    {
        //Dependency "Inventory"
        object_Inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory = object_Inventory.GetComponent<Inventory>();
        //Dependency "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        list_pickup = new List<GameObject>();
        list_screech = new List<GameObject>();
        list_event = new List<GameObject>();

        list_temp = new List<GameObject>();
        list_var1 = new List<ObjectVariables>();

        micInput = player.GetComponent<SpawnByLoudness>();

        cameraObject = GameObject.FindGameObjectWithTag("CameraObject");
        camMov = cameraObject.GetComponent<CameraMovement>();

        plController = transform.parent.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (screeching)
        {
            for (int i = 0; i < list_screech.Count; i++)
            {
                list_var1[i].force += Time.deltaTime;
            }
        }
    }

    //Changes value of bool based on collision
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "interact_pickup")
        {
            list_pickup.Add(col.gameObject);
            list_temp.Add(col.gameObject);
        }
        if (col.tag == "interact_screech")
        {
            list_screech.Add(col.gameObject);
        }
        if(col.tag == "interact_event")
        {
            list_event.Add(col.gameObject);
        }
        if(col.tag == "interact_pickup" || col.tag == "interact_screech" || col.tag == "interact_event")
        {
            ObjectVariables var = col.gameObject.GetComponent<ObjectVariables>();
            if (var.canHighlight)
            {
                var.highlight.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "interact_pickup")
        {
            list_pickup.Remove(col.gameObject);
            list_temp.Remove(col.gameObject);
        }
        if(col.tag == "interact_screech")
        {
            list_screech.Remove(col.gameObject);
        }
        if(col.tag == "interact_event")
        {
            list_event.Remove(col.gameObject);
        }
        if (col.tag == "interact_pickup" || col.tag == "interact_screech" || col.tag == "interact_event")
        {
            ObjectVariables var = col.gameObject.GetComponent<ObjectVariables>();
            if (var.canHighlight)
            {
                var.highlight.SetActive(false);
            }
        }
    }
    public void PickUp()
    {
        //Check which item is closest to the player
        while (1 < list_pickup.Count) {
            Debug.Log("searching...");
            for (int i = 0; i < list_pickup.Count; i++)
            {
                for (int j = 0; j < list_pickup.Count;)
                {
                    if (j != i)
                    {
                        if (Vector2.Distance(player.transform.position, list_pickup[j].transform.position) > Vector2.Distance(player.transform.position, list_pickup[i].transform.position))
                        {
                            list_pickup.Remove(list_pickup[j]);
                            Debug.Log("Removed object j" + j);
                            j++;
                        }
                        else
                        {
                            list_pickup.Remove(list_pickup[i]);
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
        if (list_pickup.Count > 0)
        {
            //Add item to inventory and destroy object
            var obj = (GameObject)Instantiate(list_pickup[0].transform.parent.GetComponent<ObjectVariables>().inventoryItem, transform.position, Quaternion.identity);
            inventory.AddItem(obj);
            GameObject singleObject = list_pickup[0];
            list_temp.Remove(singleObject);
            Destroy(singleObject.transform.parent.gameObject);
            list_pickup = list_temp;
        }
    }
    public void Screech()
    {
        if (micInput.ReadLoudness())
        {
            if (!screeching)
            {
                for (int i = 0; i < list_screech.Count; i++)
                {
                    list_var1.Add(list_screech[i].GetComponent<ObjectVariables>());
                }
                plController.Screech();
                camMov.ScreenShake(true);
            }
            screeching = true;
        }
        else
        {
            if (screeching)
            {
                list_var1.Clear();
                plController.ScreechEnd();
                camMov.StopShake(true);
            }
            screeching = false;
        }
    }
    public void ScreechStop()
    {
        if (screeching)
        {
            list_var1.Clear();
            plController.ScreechEnd();
            camMov.StopShake(true);
        }
        screeching = false;
    }
    public void Talk()
    {
        for (int i = 0; i < list_event.Count; i++)
        {
            list_event[i].GetComponent<ObjectVariables>().used = true;
        }

    }
}
