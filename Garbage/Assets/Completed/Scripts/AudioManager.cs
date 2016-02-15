using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public void playSound(string file)
    {
        audioSource.clip = Resources.Load(file) as AudioClip;
        audioSource.Play();
    }
}
