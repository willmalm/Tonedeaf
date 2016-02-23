using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

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
}
