using UnityEngine;
using System;
using System.Collections;

public class GridLayer : MonoBehaviour {

    public int priority;

    //Objects
    GameObject gridManagerObject;

    //Scripts
    GridManager gridManager;
    GridVariables gridVar;

	void Start () {
        //Dependancy "GridManager"
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        //Dependancy "GridVariables"
        gridVar = GetComponent<GridVariables>();
   
        UpdateLayer();
    }

    //Update position on z-axis based on current layer
    public void UpdateLayer () {
        try {
            transform.parent.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -(gridManager.maxLayers * 2 - gridVar.gridLayer * 2 + priority));
        }
        catch{
            transform.position = new Vector3(transform.position.x, transform.position.y, -(gridManager.maxLayers * 2 -gridVar.gridLayer * 2 + priority));
        }
	}
}
