using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keeper : MonoBehaviour {

    public string[] tags;
    public List<string> tags_disable;
    public Vector3 player_position;
    GameObject player;
	void Start () {
        try {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = player_position;
        }
        catch { }
	    for (int i = 0; i < tags.Length; i++)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag(tags[i]));
        }
        for (int i = 0; i < tags_disable.Count; i++)
        {
            GameObject.FindGameObjectWithTag(tags_disable[i]).SetActive(false);
        }
	}
}
