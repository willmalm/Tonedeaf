using UnityEngine;
using System.Collections;

public class OF_Dialog : MonoBehaviour {

    public bool useKey;

    public Sprite[] dialog_sprite;
    public AudioClip[] dialog_audio;

    public bool talking;
    private int currentIndex;
    GameObject player;
    PlayerVariables var_Player;
    public GameObject obj_dialog;
    SpriteRenderer sprite_dialog;
    AudioSource aud;
    ObjectVariables var;
    private bool on_start = true;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        var_Player = player.GetComponent<PlayerVariables>();
        sprite_dialog = obj_dialog.GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
        var = GetComponent<ObjectVariables>();
	}	

	void Update ()
    {
        if (var.used)
        {
            if (on_start)
            {
                StartDialog();
                on_start = false;
            }
            if (talking)
            {
                if (Input.GetKeyDown("e"))
                {
                    cycleDialog();
                }
            }
        }
	}
    public void StartDialog()
    {
        talking = true;
        var_Player.immobile = true;
        sprite_dialog.sprite = dialog_sprite[0];
        aud.clip = dialog_audio[0];
        aud.Play();
    }
    public void cycleDialog()
    {
        currentIndex++;
        if (currentIndex < dialog_sprite.Length)
        {
            sprite_dialog.sprite = dialog_sprite[currentIndex];
            aud.clip = dialog_audio[currentIndex];
            aud.Play();
        }
        else
        {
            EndDialog();
        }
    }
    public void EndDialog()
    {
        var_Player.immobile = false;
        sprite_dialog.sprite = null;
    }
}
