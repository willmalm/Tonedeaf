using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    //Public variables
    [Range(0,10)]
    public int maxLayers;
    public float tileSize;
    public float[] layers;

    void Start()
    {
        maxLayers = layers.Length-1;
    }

}
