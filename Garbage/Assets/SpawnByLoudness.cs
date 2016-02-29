using UnityEngine;
using System.Collections;

public class SpawnByLoudness : MonoBehaviour {
	public GameObject audioInputObject; // Microphone variable
	public float firstThreshold = 1.0f; // Threshold variable
	public float secondThreshold = 20.0f;
	public float thirdThreshold = 20.0f;
	MicrophoneInput micIn;


	// Use this for initialization
	void Start () {
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("MicMonitor");
		micIn = (MicrophoneInput) audioInputObject.GetComponent<MicrophoneInput>();
	}
	
	// Update is called once per frame
	void Update () {
	}
    public bool ReadThreshold1()
    {
        return micIn.loudness > firstThreshold && micIn.loudness < secondThreshold;
    }

	public bool ReadThreshold2()
	{
		return micIn.loudness > secondThreshold && micIn.loudness < secondThreshold;
	}

	public bool ReadThreshold3()
	{
		return micIn.loudness > thirdThreshold;
	}
}