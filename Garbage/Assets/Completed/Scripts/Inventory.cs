using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int maxItemsInColumn = 2;
    private List<GameObject> itemList;
    public int counter1 = 0;
    public int counter2 = 0;
    public float distance;

    public void Start()
    {
        itemList = new List<GameObject>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Item").Length; i++)
        {
            AddItem(GameObject.FindGameObjectsWithTag("Item")[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().configuringSettings == false)
        {
            UpdatePositions();
        }
    }

    public void AddItem(GameObject item)
    {
        itemList.Add(item);
        UpdatePositions();
    }
    public void RemoveItem(int index)
    {
        itemList.RemoveAt(index);
    }
    public List<GameObject> GetList()
    {
        return itemList;
    }
    public void UpdatePositions()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].GetComponent<Item>().SetInventoryPosition(counter1, counter2, distance);
            counter2++;
            if (counter2 == maxItemsInColumn)
            {
                counter2 = 0;
                counter1++;
            }
        }
        counter1 = 0;
        counter2 = 0;
    }
    public void SwapItems(int index1, int index2)
    {
        GameObject temp = itemList[index1];
        itemList[index1] = itemList[index2];
        itemList[index2] = temp;
        UpdatePositions();
    }
    public bool ItemExists(int id)
    {
        if (id == 0)
        {
            return true;
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            if(itemList[i].GetComponent<Item>().itemID == id)
            {
                return true;
            }
        }
        return false;
    }
    public GameObject GetItem(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].GetComponent<Item>().itemID == id)
            {
                return itemList[i];
            }
        }
        return null;
    }
}