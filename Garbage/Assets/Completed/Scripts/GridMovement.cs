using UnityEngine;
using System.Collections;

public class GridMovement : MonoBehaviour {

    public bool canMove = true;
    public int maxLayers;
    public int offset;
    public GameObject player;
    PlayerVariables playerVar;
    public GameObject gridObject;
    GridManager gridManager;
    PlayerController plController;

	void Start () {
        plController = player.GetComponent<PlayerController>();
        playerVar = player.GetComponent<PlayerVariables>();
        gridManager = gridObject.GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up") && canMove && playerVar.gridLayer < maxLayers - offset)
        {
            transform.position += new Vector3(0, gridManager.tileSize, 0);
            playerVar.gridLayer++;
            canMove = false;
            plController.movingUp = true;
        }
        if (Input.GetKey("down") && canMove && playerVar.gridLayer > 0 - offset)
        {
            transform.position -= new Vector3(0, gridManager.tileSize, 0);
            playerVar.gridLayer--;
            canMove = false;
            plController.movingDown = true;
        }
    }
}
