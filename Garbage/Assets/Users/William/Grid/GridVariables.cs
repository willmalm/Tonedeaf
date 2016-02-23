using UnityEngine;
using System.Collections;

public class GridVariables : MonoBehaviour {

    [Range(0, 10)]
    public int gridLayer;

    [Header("Read-only")]
    public bool canMoveY;
    public float gridPosY;

    private GameObject gridManagerObject;
    private GridManager gridManager;

    void Start()
    {
        //Dependancy "GridManager"
        gridManagerObject = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
    }
    void Update()
    {
        //Hinders current layer from exceeding the maximum and minimum amount of layers
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
