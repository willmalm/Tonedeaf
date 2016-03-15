using UnityEngine;
using System.Collections;

public class OF_Niise : MonoBehaviour {
    public GameObject dialog;
    ObjectVariables var;
    // Use this for initialization
    void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            dialog.SetActive(true);
        }
	}
}
