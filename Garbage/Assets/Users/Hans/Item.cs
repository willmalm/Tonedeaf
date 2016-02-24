using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    GameObject inventory;

    public void SetInventoryPosition(float xPosition, float yPosition, float distance)
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        transform.SetParent(inventory.transform);
        transform.position = inventory.transform.position + new Vector3(xPosition * distance, yPosition * distance, 0);
    }
    public void Effect()
    {

    }
}
