using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    GameObject inventory;
    // Use this for initialization
    public void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void SetInventoryPosition(float xPosition, float yPosition, float distance)
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        transform.SetParent(inventory.transform);
        transform.position = inventory.transform.position + new Vector3(xPosition * distance, (yPosition) * distance, 0);
    }
    public void Effect()
    {

    }
}
