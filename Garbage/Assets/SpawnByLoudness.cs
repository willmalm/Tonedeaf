using UnityEngine;
using System.Collections;

public class SpawnByLoudness : MonoBehaviour {
	public GameObject audioInputObject;
	public float threshold = 1.0f;
	public GameObject objectToSpawn;
	public float speed = 1.0f;
	public float fade = 1.0f;
	MicrophoneInput micIn;


	// Use this for initialization
	void Start () {
		if (objectToSpawn == null)
			Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("MicMonitor");
		micIn = (MicrophoneInput) audioInputObject.GetComponent<MicrophoneInput>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (micIn.loudness);
		if (micIn.loudness > threshold)
		{
			Vector3 scale = new Vector3(micIn.loudness,micIn.loudness,micIn.loudness);
			GameObject newObject = (GameObject)Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
			// newObject.transform.localScale += scale;
		}
	}
}
