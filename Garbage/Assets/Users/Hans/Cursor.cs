using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Cursor : MonoBehaviour
{
    private bool isActive = true; //is true if the inventory is active, false if inventory is not active
    public int selectedItem1 = -1; //value cannot be an index in the inventory
    public int selectedItem2 = -1; //value cannot be an index in the inventory
    public Text text;
    public Text text2;
    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (isActive && GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().configuringSettings == false)
        {
            if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[2]))
            {
                transform.position += new Vector3(0, 1, 0);
            }
            else if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[3]))
            {
                transform.position += new Vector3(0, -1, 0);
            }
            else if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[0]))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[1]))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[4]))
            {
                SwapItems();
            }
            else if (Input.GetKeyDown(GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().input[8]))
            {
                AdjustSettings();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().function = Settings.Function.AssignKey;
                GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().index = 0;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                text.text = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetList().Count.ToString();
            }
        }
    }

    public void SetStatus(bool value)
    {
        isActive = value;
    }
    private void SwapItems() //first function call selects an item, second call selects second item and swaps their positions in Inventory's list
    {
        List<GameObject> itemsInInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetList();
        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            if (itemsInInventory[i].transform.position == this.transform.position + new Vector3(0, 0, 1))
            {
                if (selectedItem1 == -1)
                {
                    selectedItem1 = i;
                }
                else
                {
                    selectedItem2 = i;
                    GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().SwapItems(selectedItem1, selectedItem2);
                    selectedItem1 = -1;
                    selectedItem2 = -1;
                }
                break;
            }
        }
    }
    private void AdjustSettings()
    {
        GameObject[] changeKeyID = GameObject.FindGameObjectsWithTag("KeyID");
        for (int i = 0; i < changeKeyID.Length; i++)
        {
            if (changeKeyID[i].transform.position == this.transform.position + new Vector3(0, 0, 1))
            {
                GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().SetTemporaryArray();
                GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().function = Settings.Function.AssignKey;
                GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().index = changeKeyID[i].GetComponent<KeyID>().keyID;
                break;
            }
        }
    }
    private void EquipItem()
    {
        List<GameObject> itemsInInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().GetList();
        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            if (itemsInInventory[i].transform.position == this.transform.position + new Vector3(0, 0, 1))
            {
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().EquipItem(i);
                break;
            }
        }
    }
}
