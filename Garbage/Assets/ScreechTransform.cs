using UnityEngine;
using System.Collections;

public class ScreechTransform : MonoBehaviour {
	public float speed = 1;
	public float fade = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, Time.deltaTime * fade);
	}
}
