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
            Debug.Log(1);
            note.SetActive(true);
            var_player.immobile = true;
            
        }
        else
        {
            if (note.active == true)
            {
                var_player.immobile = false;
                note.SetActive(false);

            }
        }
	}
}
