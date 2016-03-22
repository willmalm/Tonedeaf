using UnityEngine;
using System.Collections;

public class OF_Toilet : MonoBehaviour {

    public Sprite spr;
    ObjectVariables var;
    SpriteRenderer sprite;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
        sprite = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            sprite.sprite = spr;
            aud.Play();
            var.used = false;
            var.toughness = 10;
        }
	}
}
