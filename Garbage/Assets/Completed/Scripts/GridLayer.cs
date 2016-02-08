using UnityEngine;
using System;
using System.Collections;

public class GridLayer : MonoBehaviour {
    SpriteRenderer spr;
    GameObject gridManagerObject;
    GridManager gridManager;
    GridVariables gridVar;

	void Start () {
        spr = GetComponent<SpriteRenderer>();
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        try{
            gridVar = transform.parent.gameObject.GetComponent<GridVariables>();
        }
        catch
        {
            gridVar = GetComponent<GridVariables>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        spr.sortingOrder = gridManager.maxLayers/* - gridVar.gridLayer*/;
	}

}
