using UnityEngine;
using System.Collections;

public class OF_Testing : MonoBehaviour {

    ObjectVariables var;
    public GameObject testScreen;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            testScreen.SetActive(true);
        }
	}
}
