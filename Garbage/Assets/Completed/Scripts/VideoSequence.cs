using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VideoSequence : MonoBehaviour
{
	private AudioSource audioSource;
	public MovieTexture movie;
	public bool playOnAwake;
	public int sceneIndex; //-1 if no sceneChange
	private bool wait = false;
	public float timer = 0;
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
				if (sceneIndex == -1) 
				{
					gameObject.SetActive(false);
				}
				else 
				{
					SceneManager.LoadScene(sceneIndex);
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