using UnityEngine;
using System.Collections;

public class ExamplePlayer : MonoBehaviour 
{
    private GameObject equippedItem = null;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (false) //interact
        {
            equippedItem.GetComponent<Item>().Effect();
        }
	}
    public void EquipItem(GameObject item)
    {
        equippedItem = item;
    }
}
