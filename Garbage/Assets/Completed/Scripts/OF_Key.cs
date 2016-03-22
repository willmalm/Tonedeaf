using UnityEngine;
using System.Collections;

public class OF_Key : MonoBehaviour {

    public GameObject key;
    public float posY;
    public float speed;
    ObjectVariables var;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            try {
                if (key.transform.position.y > transform.position.y + posY) {
                    key.transform.Translate(-Vector3.up * speed * Time.deltaTime);
                }
            }
            catch { }
        }
	}
}
