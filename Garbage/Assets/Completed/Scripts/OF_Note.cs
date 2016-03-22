using UnityEngine;
using System.Collections;

public class OF_Note : MonoBehaviour
{
    ObjectVariables var;
    public GameObject note;
    public Sprite sprite;
    PlayerVariables var_player;
    GameObject player;
    GameObject inventory;
    Inventory inv;
    AudioSource aud;
    public GameObject key;
    bool first;
    bool second;
	void Start ()
    {
        var = GetComponent<ObjectVariables>();
        player = GameObject.FindGameObjectWithTag("Player");
        var_player = player.GetComponent<PlayerVariables>();
        inventory = GameObject.FindGameObjectWithTag("GLOBAL_inventory");
        inv = inventory.GetComponent<Inventory>();
        aud = GetComponent<AudioSource>();
	}

	void Update ()
    {
	    if (var.used)
        {

            note.SetActive(true);
            var_player.im_event = true;
            first = true;
            
        }
        else
        {
            if (note.active == true)
            {
                if (first)
                {
                    note.GetComponent<SpriteRenderer>().sprite = sprite;
                    if (!second)
                    {
                        aud.Play();
                        var obj = (GameObject)Instantiate(key, transform.position, Quaternion.identity);
                        inv.AddItem(obj);
                        second = true;
                    }
                }
                var_player.im_event = false;
                note.SetActive(false);

            }
        }
	}
}
