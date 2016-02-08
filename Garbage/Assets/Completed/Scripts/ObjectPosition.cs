using UnityEngine;
using System.Collections;

public class ObjectPosition : MonoBehaviour {

    ObjectVariables objectVar;
    GameObject gridObject;
    GridManager gridManager;
    SpriteRenderer spr;
	// Use this for initialization
	void Start () {
        objectVar = GetComponent<ObjectVariables>();
        spr = GetComponent<SpriteRenderer>();
        gridObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridObject.GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, objectVar.gridLayer, 0);
        spr.sortingOrder = gridManager.maxLayers-objectVar.gridLayer-1;
	}
}
