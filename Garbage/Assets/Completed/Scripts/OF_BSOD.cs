using UnityEngine;
using System.Collections;

public class OF_BSOD : MonoBehaviour
{
    ObjectVariables var;
    public GameObject bsod;
    PlayerVariables var_player;
    GameObject player;
    GameObject audioManager;
    AudioSource aud;
    void Start()
    {
        var = GetComponent<ObjectVariables>();
        player = GameObject.FindGameObjectWithTag("Player");
        var_player = player.GetComponent<PlayerVariables>();
        audioManager = GameObject.FindGameObjectWithTag("GLOBAL_audio");
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (var.used)
        {
            if (bsod.active == false)
            {
                bsod.SetActive(true);
                var_player.im_event = true;
                var.force = 0;
                var.toughness = 3;
                var.used = false;
                aud.Play();
                audioManager.GetComponent<AudioSource>().Stop();
            }
            else
            {
                bsod.SetActive(false);
                var_player.im_event = false;
                var.force = 0;
                var.toughness = 2;
                var.used = false;
                aud.Stop();
                audioManager.GetComponent<AudioSource>().Play();
            }

        }
        
    }
}
