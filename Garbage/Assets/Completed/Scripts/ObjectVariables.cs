using UnityEngine;
using System.Collections;

public class ObjectVariables : MonoBehaviour {


    public string objName;

    [Header("Global")]
    public int type; //The type of interactable object
    public bool used;
    [Space(10)]
    public bool canHighlight;
    public GameObject highlight;

    [Header("Pickup")]
    public bool canPickup;
    public GameObject inventoryItem;

    [Header("Screech")]
    public float force;
    public float toughness;

    [Header("Event")]
    public bool requiresItem;
    public int itemID;

    void Update()
    {
        //Screech
        if (type == 1)
        {
            if (force >= toughness)
            {
                used = true;
            }
            else
            {
                used = false;
            }
        }
    }
}
