using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VideoSequence : MonoBehaviour
{
	private AudioSource audioSource;
    private AudioSource audioManager;
	public MovieTexture movie;
    private PlayerVariables plVar;
	public bool playOnAwake;
	public int sceneIndex; //-1 if no sceneChange
	private bool wait = false;
	public float timer = 0;
	void Start () 
	{
        try
        {
            plVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
            audioManager = GameObject.FindGameObjectWithTag("GLOBAL_audio").GetComponent<AudioSource>();
        }
        catch
        {

        }
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
           if (audioManager != null)
            {
                audioManager.Pause();
            }
            if (Input.anyKeyDown && timer > 15f)
            {
                SceneManager.LoadScene(sceneIndex);
            }
			timer += Time.deltaTime;
            if(plVar != null)
            {
                plVar.im_event = true;
            }
			if (timer > movie.duration)
			{
				if (sceneIndex == -1) 
				{
                    if (plVar != null)
                    {
                        plVar.im_event = false;
                    }
                    if (audioManager != null)
                    {
                        audioManager.UnPause();
                    }
					gameObject.SetActive(false);
				}
				else 
				{
					SceneManager.LoadScene(sceneIndex);
                    if (audioManager != null)
                    {
                        audioManager.Stop();
                    }
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