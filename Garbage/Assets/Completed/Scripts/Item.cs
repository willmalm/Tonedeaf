using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public int itemID;
    private GameObject inventory;

    public void SetInventoryPosition(float xPosition, float yPosition, float distance)
    {
        inventory = GameObject.FindGameObjectWithTag("GLOBAL_inventory");
        transform.SetParent(inventory.transform);
        transform.position = inventory.transform.position + new Vector3(xPosition * distance, yPosition * distance, 0);
    }
}
