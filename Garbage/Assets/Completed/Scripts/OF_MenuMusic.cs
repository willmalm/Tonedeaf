using UnityEngine;
using System.Collections;

public class OF_MenuMusic : MonoBehaviour {

    public float time;
    float timer;
    public AudioSource aud;
    public AudioClip loop;
    bool first = true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	    if(timer >= time && first)
        {
            aud.clip = loop;
            aud.Play();
            first = false;
        }
	}
}
