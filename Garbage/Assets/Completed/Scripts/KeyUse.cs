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
        //Dependency "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = GameObject.FindGameObjectWithTag("plInteract");
        plController = player.GetComponent<PlayerController>();
        plInteraction = playerInteract.GetComponent<Interaction>();
        //Dependency "Inventory"
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
        else if (Input.GetKey(keys[3]))
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
        //Scrrech
        if (Input.GetKeyDown(keys[6]))
        {
            plController.interactingWithScreech = true;
            plController.Screech();
        }
        else if (Input.GetKeyUp(keys[6]))
        {
            plController.interactingWithScreech = false;
            plController.ScreechEnd();
        }
	}
}
