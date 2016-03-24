using UnityEngine;
using System.Collections;

public class OF_Windows : MonoBehaviour {
    public GameObject cracks;
    ObjectVariables var;
    AudioSource aud;
    bool first = true;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            if (first)
            {
                cracks.SetActive(true);
                aud.Play();
                cracks.GetComponent<AudioSource>().Play();
                first = false;
            }
        }
	}
}
