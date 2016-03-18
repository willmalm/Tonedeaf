using UnityEngine;
using System.Collections;

public class gott : MonoBehaviour {
	[Range(0,10)]
	public float speed = 1;
	[Range(0,10)]
	public float strength = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += Vector3.up * Mathf.Sin((Time.realtimeSinceStartup)*51 * speed) * 0.01f * strength;
		transform.localPosition += Vector3.right * Mathf.Sin((Time.realtimeSinceStartup + 0.24242f)*49 * speed) * 0.0075f * strength;

		transform.localPosition += Vector3.up * Mathf.Sin((Time.realtimeSinceStartup)*74 * speed) * 0.004f * strength;
		transform.localPosition += Vector3.right * Mathf.Sin((Time.realtimeSinceStartup + 0.76f)*85 * speed) * 0.0005f * strength;
	}
}
