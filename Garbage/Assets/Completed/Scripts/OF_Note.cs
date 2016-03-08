using UnityEngine;
using System.Collections;

public class OF_Note : MonoBehaviour
{
    ObjectVariables var;
    public GameObject note;
    PlayerVariables var_player;
    GameObject player;
	void Start ()
    {
        var = GetComponent<ObjectVariables>();
        player = GameObject.FindGameObjectWithTag("Player");
        var_player = player.GetComponent<PlayerVariables>();
	}

	void Update ()
    {
	    if (var.used)
        {
            note.SetActive(true);
            var_player.im_event = true;
            
        }
        else
        {
            if (note.active == true)
            {
                var_player.im_event = false;
                note.SetActive(false);

            }
        }
	}
}
