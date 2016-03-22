using UnityEngine;
using System.Collections;

public class OF_Radio : MonoBehaviour {

    GameObject audioManager;
    public AudioClip[] clips;
    AudioSource aud;
    ObjectVariables var;
    GameObject player;
    PlayerVariables var_player;
    int currentIndex = 1;
    int randomValue;
    int orgIndex;
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
        if (var.used)
        {
            randomValue = Random.Range(0, 10);
            if (randomValue == 9)
            {
                orgIndex = currentIndex;
                currentIndex = 0;
                var_player.im_event = true;
            }
            else
            {
                Forward();
                orgIndex = currentIndex;
                var_player.im_event = false;
            }
            aud.clip = clips[currentIndex];
            currentIndex = orgIndex;
            aud.Play();
            var.force = 0;
            var.used = false;
            var.highlight.SetActive(true);             
            
        }
	}
    void Forward()
    {
        currentIndex++;
        if(currentIndex > clips.Length-1)
        {
            currentIndex = 1;
        }
    }
}
