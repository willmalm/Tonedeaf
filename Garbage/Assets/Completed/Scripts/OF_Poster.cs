using UnityEngine;
using System.Collections;

public class OF_Poster : MonoBehaviour {

    ObjectVariables var;
    SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (var.used)
        {
            sprite.color -= new Color(0, 0, 0, Time.deltaTime);
        }
	}
}
