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
		Debug.Log (micIn.loudness);
		if (Input.GetKey(KeyCode.H) && micIn.loudness > firstThreshold) // If-statement that executes if the H-key is held down and the microphone level is above Threshold
		{
			
		}
	}
    public bool ReadThreshold1()
    {
        return micIn.loudness > firstThreshold && micIn.loudness < secondThreshold;
    }

	public bool ReadThershold2()
	{
		return micIn.loudness > secondThreshold && micIn.loudness < secondThreshold;
	}

	public bool ReadThreshold3(){
	{
		return micIn.loudness > thirdThreshold;
	}
}
