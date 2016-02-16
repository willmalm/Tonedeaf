using UnityEngine;
using System.Collections;

public class Screech : MonoBehaviour {

    AudioSource aud;
    public GameObject player;

	void Start () {
        aud = player.GetComponent<AudioSource>();
	}
	
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "scrObject" && Input.GetKey("s"))
        {
            col.gameObject.GetComponent<ObjectVariables>().force++;
            aud.clip = Resources.Load("Scream_5_01") as AudioClip;
            aud.Play();
        }
        else
        {
            aud.Stop();
        }
    }
}
