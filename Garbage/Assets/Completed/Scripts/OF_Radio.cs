using UnityEngine;
using System.Collections;

public class OF_Radio : MonoBehaviour {

    GameObject audioManager;
    public AudioClip[] clips;
    AudioSource aud;
    ObjectVariables var;
    GameObject player;
    PlayerVariables var_player;
    int currentIndex;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        audioManager = GameObject.FindGameObjectWithTag("GLOBAL_audio");
        aud = audioManager.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        var_player = player.GetComponent<PlayerVariables>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentIndex == 1)
        {
            var_player.immobile = true;

        }
        if (var.used)
        {

            currentIndex = Random.Range(0, clips.Length);
            if (aud.clip != clips[currentIndex])
            {
                aud.clip = clips[currentIndex];
                aud.Play();
                var.force = 0;
                var.used = false;               
            }
            else
            {
                currentIndex = Random.Range(0, clips.Length);
            }
        }
	}
}
