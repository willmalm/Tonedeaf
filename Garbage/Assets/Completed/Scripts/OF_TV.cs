using UnityEngine;
using System.Collections;

public class OF_TV : MonoBehaviour {
    public GameObject sprite;
    TVController controller;
    ObjectVariables var;
    bool once = true;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        controller = sprite.GetComponent<TVController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used && once)
        {
            controller.value = 0;
            once = false;
        }
        else if(var.used == false)
        {
            controller.value = 1;
        }
	}
}
