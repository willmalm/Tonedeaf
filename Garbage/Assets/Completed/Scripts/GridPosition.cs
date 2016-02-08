using UnityEngine;
using System.Collections;

public class GridPosition : MonoBehaviour {

    GameObject gridManagerObject;
    GridManager gridManager;
    GridVariables gridVar;
    PlayerVariables playerVar;

    bool movingUp;
    bool movingDown;

	void Start () {
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        gridVar = GetComponent<GridVariables>();
        playerVar = GetComponent<PlayerVariables>();

        transform.position = new Vector3(transform.position.x, gridVar.gridLayer * gridManager.tileSize);
	}

	void Update () {
        gridVar.gridPosY = gridVar.gridLayer * gridManager.tileSize;
        if (gridVar.gridPosY < transform.position.y && gridVar.gridLayer >= 0)
        {
            movingDown = true;
        }
        else if (gridVar.gridPosY > transform.position.y && gridVar.gridLayer <= gridManager.maxLayers )
        {
            movingUp = true;
        }
        else if(movingUp == false && movingDown == false){
            //idle
            gridVar.canMove = true;
        }
        if (movingDown)
        {
            //gridVar.canMove = false;
            transform.position += new Vector3(0, -(playerVar.speed / 2) * Time.deltaTime, 0);
            if (transform.position.y <= gridVar.gridPosY)
            {
                transform.position = new Vector3(transform.position.x, gridVar.gridPosY, 0);
                movingDown = false;
                gridVar.canMove = true;
            }
        }
        if (movingUp)
        {
            //gridVar.canMove = false;
            transform.position += new Vector3(0, (playerVar.speed / 2) * Time.deltaTime, 0);
            if (transform.position.y >= gridVar.gridPosY)
            {
                transform.position = new Vector3(transform.position.x, gridVar.gridPosY, 0);
                movingUp = false;
                gridVar.canMove = true;
            }
        }
    }
}
