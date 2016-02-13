using UnityEngine;
using System.Collections;

public class ObjectVariables : MonoBehaviour {

    public string objName;
    public bool canPickup;
    public GameObject highlight;
    public GameObject inventoryItem;
    public bool used;
    public float force;
    public float toughness;

    void Update()
    {
        if(force >= toughness)
        {
            used = true;
        }
        else
        {
            used = false;
        }
    }
}
