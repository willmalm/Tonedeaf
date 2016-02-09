using UnityEngine;
using System.Collections;

public class GridPosition : MonoBehaviour {

    //Objects
    private GameObject gridManagerObject;

    //Scripts
    private GridManager gridManager;
    private PlayerVariables playerVar;
    private GridVariables gridVar;
    private GridLayer gridLayer;

    bool movingUp;
    bool movingDown;

	void Start () {
        //Dependancy "GridManager"
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        //Dependancy "GridVariables", "PlayerVariables"
        gridVar = GetComponent<GridVariables>();
        playerVar = GetComponent<PlayerVariables>();
        //Dependancy "GridLayer"
        gridLayer = GetComponent<GridLayer>();

        //Set position of object based on current layer
        transform.position = new Vector3(transform.position.x, gridVar.gridLayer * gridManager.tileSize);
	}

	void Update () {
        //Updates target position
        gridVar.gridPosY = gridVar.gridLayer * gridManager.tileSize;

        //Change value of bools depending on object position
        if (gridVar.gridPosY < transform.position.y && gridVar.gridLayer >= 0)
        {
            movingDown = true;
        }
        else if (gridVar.gridPosY > transform.position.y && gridVar.gridLayer <= gridManager.maxLayers )
        {
            movingUp = true;
        }
        else if(movingUp == false && movingDown == false){
            gridVar.canMoveY = true;
        }

        //Translate object based on value of bools
        if (movingDown)
        {
            transform.position += new Vector3(0, -(playerVar.speed / 2) * Time.deltaTime, 0);
            if (transform.position.y <= gridVar.gridPosY)
            {
                transform.position = new Vector3(transform.position.x, gridVar.gridPosY, 0);
                gridLayer.UpdateLayer();
                movingDown = false;
                gridVar.canMoveY = true;
            }
        }
        else if (movingUp)
        {
            transform.position += new Vector3(0, (playerVar.speed / 2) * Time.deltaTime, 0);
            if (transform.position.y >= gridVar.gridPosY)
            {
                transform.position = new Vector3(transform.position.x, gridVar.gridPosY, 0);
                gridLayer.UpdateLayer();
                movingUp = false;
                gridVar.canMoveY = true;
            }
        }
    }
}
