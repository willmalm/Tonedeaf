using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource audioSource;
    AudioClip clip;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void PlaySound(string file)
    {
        audioSource.clip = Resources.Load(file) as AudioClip;
        audioSource.Play();
    }
    public void PlayOneShot(string file)
    {
        clip = Resources.Load(file) as AudioClip;
        audioSource.PlayOneShot(clip);
    }
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level " + level + " loaded");
        try
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource.clip != clips[level])
            {
                audioSource.clip = clips[level];
                audioSource.Play();
            }
        }
        catch
        {
            Debug.Log("Failed to play audio (Most likely irrelevant)");
        }
    }

}
