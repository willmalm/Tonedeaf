using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

    //Public variables
    public bool activated;
    [Header("GameObjects")]
    public GameObject dialogObj;
    [Header("Scripts")]
    public NPCBehavior movement;
    [Space(10)]
    [Range(0, 10)]
    public int range;
    public Sprite portrait;
    [TextArea(3, 10)]
    public string[] lines;
    public GameObject[] items;
    public GameObject[] events;

    //Objects
    GameObject player;

    //Scripts
    private DialogFunction dialog;
    private GridVariables NPCGridVar;
    private GridVariables plGridVar;

    private float leftRange;
    private float rightRange;
    private bool currentlyTalking;

    void Start () {
        //Dependancy "DialogFunction"
        dialog = dialogObj.GetComponent<DialogFunction>();
        //Dependancy "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        //Dependancy "Player GridVariables", "NPC GridVariables"
        plGridVar = player.GetComponent<GridVariables>();
        NPCGridVar = GetComponent<GridVariables>();
	}

	void Update () {
        //Update directional range based on modifiable value
        leftRange = transform.position.x - range;
        rightRange = transform.position.x + range;

        //Starts dialog on keypress
	    if (Input.GetKeyDown("d") && activated && player.transform.position.x < rightRange && player.transform.position.x > leftRange && NPCGridVar.gridLayer == plGridVar.gridLayer)
        {
            dialog.startDialog(lines, items, events, portrait);
            currentlyTalking = true;
            activated = false;
        }
        if (currentlyTalking && dialog.active == false)
        {
            currentlyTalking = false;
        }
        if (currentlyTalking)
        {
            movement.active = false;
        }
        else
        {
            movement.active = true;
        }
	}
}
