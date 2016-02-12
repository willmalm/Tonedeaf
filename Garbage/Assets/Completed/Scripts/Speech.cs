using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    //Public variables
    [Range(0,10)]
    public int range;
    public GameObject speech;

    //Objects
    private GameObject player;

    //Scripts
    private GridVariables plGridVar;
    private GridVariables gridVar;

	void Start () {
        //Dependancy "Player", "Player GridVariables"
        player = GameObject.FindGameObjectWithTag("Player");
        plGridVar = player.GetComponent<GridVariables>();
        //Dependancy "GridVariables"
        gridVar = GetComponent<GridVariables>();
	}

	void Update () {
        //Shows speech bubble if player is within range
	    if (player.transform.position.x > transform.position.x-range && player.transform.position.x < transform.position.x + range)
        {
            speech.SetActive(true);
        }
        else
        {
            speech.SetActive(false);
        }
	}
}
