using UnityEngine;
using System.Collections;

public class OF_Ask : MonoBehaviour {
    public GameObject smoke;
    ObjectVariables var;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            smoke.SetActive(true);
        }
	}
}
