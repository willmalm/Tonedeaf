using UnityEngine;
using System.Collections;

public class GridVariables : MonoBehaviour {
    [Range(0, 10)]
    public int gridLayer;
    public bool canMove;
    public int gridPosY;

    GameObject gridManagerObject;
    GridManager gridManager;
    void Start()
    {
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
    }
    void Update()
    {
        if (gridLayer > gridManager.maxLayers)
        {
            gridLayer = gridManager.maxLayers;
        }
        if(gridLayer < 0)
        {
            gridLayer = 0;
        }
    }
}
