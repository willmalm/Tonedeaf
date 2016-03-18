using UnityEngine;
using System.Collections;

public class VideoSequence : MonoBehaviour
{
	public Sprite[] video;
	public AudioClip videoSound;
	private AudioSource audioSource;
	private SpriteRenderer sprite;
	private int index = 0;
	private int delay = 0;
	private bool play = false;
	void Start () 
	{
		gameObject.SetActive(false);
		sprite = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = videoSound;
	}

	void Update () 
	{
		if (play)
		{
			sprite.sprite = video[index];
			delay++;
			if (delay % 5 == 0) 
			{
				index++;
			}
			if (index == video.Length) 
			{
				index = 0;
			}
		}
	}
	public void Play()
	{
		gameObject.SetActive(true);
		play = true;
		audioSource.Play();
	}
}
