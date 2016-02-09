using UnityEngine;
using System;
using System.Collections;

public class GridLayer : MonoBehaviour {

    GameObject gridManagerObject;
    GridManager gridManager;
    GridVariables gridVar;
    public int offset;

	void Start () {
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        gridVar = GetComponent<GridVariables>();
        UpdateLayer();
    }
	
	// Update is called once per frame
	public void UpdateLayer () {
        //spr.sortingOrder = gridManager.maxLayers*2 - gridVar.gridLayer*2 + offset;
        try {
            transform.parent.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -(gridManager.maxLayers * 2 - gridVar.gridLayer * 2 + offset));
        }
        catch
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -(gridManager.maxLayers * 2 -gridVar.gridLayer * 2 + offset));
        }
	}

}
