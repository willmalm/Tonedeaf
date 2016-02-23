using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]


public class MicrophoneInput : MonoBehaviour {
	public float sensitivity = 50f;
	public float loudness = 0;

	// Use this for initialization
	void Start ()
	{
		GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 48000);
		GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
		GetComponent<AudioSource>().mute = false; // Mute the sound, we don't want the player to hear it
		while (!(Microphone.GetPosition(null) > 0)){} // Wait until the recording has started
		GetComponent<AudioSource>().Play(); // Play the audio source!
	}

	// Update is called once per frame
	void Update () {
		loudness = GetAveragedVolume() * sensitivity;
	}

	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		GetComponent<AudioSource>().GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}
}

