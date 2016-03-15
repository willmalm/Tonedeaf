using UnityEngine;
using System.Collections;

public class OF_Sign : MonoBehaviour {
    ObjectVariables var;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            transform.eulerAngles += new Vector3(0, 0, Time.deltaTime);
            
        }
	}
}
