using UnityEngine;
using System.Collections;

public class OF_Niise : MonoBehaviour {
    public GameObject dialog;
    public GameObject item;
    float timer;
    bool first = true;
    Inventory inv;
    ObjectVariables var;
    // Use this for initialization
    void Start () {
        var = GetComponent<ObjectVariables>();
        inv = GameObject.FindGameObjectWithTag("GLOBAL_inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            if (inv.ItemExists(2) && first)
            {
                inv.RemoveItem(0);
                GameObject item1 = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
                inv.AddItem(item1);
                first = false;
                var.force = 0;
                var.used = false;
            }
            else
            {
                if (first)
                {
                    if (timer == 0 || timer > 2)
                    {
                        dialog.SetActive(false);
                        var.force = 0;
                        var.used = false;
                    }
                    else
                    {
                        dialog.SetActive(true);
                    }
                    timer += Time.deltaTime;
                }
            }
        }
	}
}
