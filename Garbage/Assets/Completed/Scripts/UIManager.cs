using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    //Public variables
    public GameObject pauseWindow;
    public GameObject savePrompt;
    [Space(5)]
    public int invSpeed;
    public int invEnabledPos;
    public int invDisabledPos;
    [Header("Read-only")]
    public float invInvisible;
    public float invVisible;
    public bool pauseBool = true;

    //Objects
    private GameObject inventory;
    private GameObject map;
    private GameObject player;

    private bool invEnabled;
    private Vector3 invCurrent;

    void Start()
    {
        //Dependancy "Player", "Inventory"
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update () {
        //Set position for inventory states based on player position
        invInvisible = player.transform.position.x + invDisabledPos;
        invVisible = player.transform.position.x + invEnabledPos;

        //Show "Pause Window" on keypress
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseWindow.SetActive(pauseBool);
            pauseBool = !pauseBool;
        }
        //Show "Inventory" on keypress
        if (Input.GetKeyDown(KeyCode.I))
        {
            invCurrent = inventory.transform.position;
            invEnabled = !invEnabled;
           /* foreach (Transform child in inventory.transform)
            {
                //child.gameObject.SetActive(inv);
            }*/
        }
        //Change position of inventory based on current state
        if (invEnabled)
        {
            if (inventory.transform.position.x < invVisible)
            {
                inventory.transform.position += new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                inventory.transform.position = new Vector3(invVisible, inventory.transform.position.y, 0);
            }
        }
        else if (invEnabled == false)
        {

            if (inventory.transform.position.x > invInvisible)
            {
                inventory.transform.position -= new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                inventory.transform.position = new Vector3(invInvisible, inventory.transform.position.y, 0);
            }
        }
	}
}
