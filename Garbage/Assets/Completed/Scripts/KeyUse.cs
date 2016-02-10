using UnityEngine;
using System.Collections;

public class KeyUse : MonoBehaviour {

    //Public variables
    public string[] keys;

    //Objects
    private GameObject player;
    private GameObject playerInteract;
    private GameObject inventory;

    //Scripts
    private PlayerController plController;
    private Interaction plInteraction;
    private InventoryUI inventoryUI;

    void Start () {
        //Dependancy "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = GameObject.FindGameObjectWithTag("plInteract");
        plController = player.GetComponent<PlayerController>();
        plInteraction = playerInteract.GetComponent<Interaction>();
        //Dependancy "Inventory"
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventoryUI = inventory.GetComponent<InventoryUI>();
	}
	
	void Update () {
        //Player movement
        if (Input.GetKey(keys[0]))
        {
            plController.MoveRight();
        }
        else if (Input.GetKey(keys[1]))
        {
            plController.MoveLeft();
        }
        else
        {
            plController.Idle();
        }
        if (Input.GetKey(keys[2]))
        {
            plController.MoveUp();
        }
        if (Input.GetKey(keys[3]))
        {
            plController.MoveDown();
        }
        //Pick up item
        if (Input.GetKeyDown(keys[4]))
        {
            plInteraction.PickUp();
        }
        //Change inventory state
        if (Input.GetKeyDown(keys[5]))
        {
            inventoryUI.ChangeState();
        }
	}
}
