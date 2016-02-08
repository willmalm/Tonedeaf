using UnityEngine;
using System.Collections;

public class GridObjectPosition : MonoBehaviour {

    GameObject gridManagerObject;
    GridManager gridManager;
    GridVariables gridVar;

    void Start()
    {
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        gridVar = GetComponent<GridVariables>();

        transform.position = new Vector3(transform.position.x, gridVar.gridLayer * gridManager.tileSize);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
