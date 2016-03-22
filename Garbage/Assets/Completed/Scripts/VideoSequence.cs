using UnityEngine;
using System.Collections;

public class VideoSequence : MonoBehaviour
{
	private AudioSource audioSource;
	public MovieTexture movie;
	public bool playOnAwake;
	public int sceneIndex; //-1 if no sceneChange
	private bool wait = false;
	private float timer = 0;
	private SceneChanger sceneChanger;
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		GetComponent<Renderer>().material.mainTexture = movie;
		if (playOnAwake) 
		{
			Play();
		}
	}
	void Update()
	{
		if (wait)
		{
			timer += Time.deltaTime;
			if (timer > movie.duration)
			{
				if (sceneIndex != -1) 
				{
					gameObject.SetActive(false);
				}
				else 
				{
					sceneChanger.LoadScene(sceneIndex, true, new Vector3(0f, 0f, 0f));
				}
			}
		}
	}
	public void Play()
	{
		audioSource.Play();
		movie.Play();
		wait = true;
	}
}