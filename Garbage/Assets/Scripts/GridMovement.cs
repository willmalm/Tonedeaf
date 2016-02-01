using UnityEngine;
using System.Collections;

public class GridMovement : MonoBehaviour {

    public bool canMove = true;
    public int maxLayers;
    public GameObject player;
    PlayerVariables playerVar;
    playerController plController;
	// Use this for initialization
	void Start () {
        plController = player.GetComponent<playerController>();
        playerVar = player.GetComponent<PlayerVariables>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey("up") && canMove && playerVar.gridLayer < maxLayers)
        {
            transform.position += new Vector3(0, 1, 0);
            playerVar.gridLayer++;
            canMove = false;
            plController.movingUp = true;
        }
        if (Input.GetKey("down") && canMove && playerVar.gridLayer > 0)
        {
            transform.position -= new Vector3(0, 1, 0);
            playerVar.gridLayer--;
            canMove = false;
            plController.movingDown = true;
        }
    }
}
