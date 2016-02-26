using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {

    //Public variables
    public string[] keys;

    //Objects
    private GameObject player;
    private GameObject playerInteract;
    private GameObject sprite_inventory;
    private GameObject cameraObject;

    //Scripts
    private PlayerController plController;
    private Interaction plInteraction;
    private InventoryUI inventoryUI;
    private CameraMovement camMov;

    void Start () {
        //Dependency "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = GameObject.FindGameObjectWithTag("plInteract");
        plController = player.GetComponent<PlayerController>();
        plInteraction = playerInteract.GetComponent<Interaction>();
        //Dependency "Inventory"
        sprite_inventory = GameObject.FindGameObjectWithTag("SpriteInventory");
        inventoryUI = sprite_inventory.GetComponent<InventoryUI>();

        cameraObject = GameObject.FindGameObjectWithTag("CameraObject");
        camMov = cameraObject.GetComponent<CameraMovement>();
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
        //Screech
        if (Input.GetKey(keys[6]))
        {

            //plController.Screech();
            plInteraction.Screech();
            //camMov.ScreenShake(true);
            
        }
        else
        {
            //plController.ScreechEnd();
            plInteraction.ScreechStop();
            //camMov.StopShake(true);
        }
    }
}
