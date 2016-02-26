﻿using UnityEngine;
using System.Collections;

public class ObjectVariables : MonoBehaviour {


    public string objName;

    //Global
    public int type; //The type of interactable object

    public bool used;
    public bool canHighlight;
    public GameObject highlight;

    //Pickup
    public bool canPickup;
    public GameObject inventoryItem;

    //Screech
    public float force;
    public float toughness;

    //Interact
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
