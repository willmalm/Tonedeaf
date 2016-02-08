using UnityEngine;
using System.Collections;

public class W_SpriteSize : MonoBehaviour {

	public float angle;
	public float size;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
	{
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		sprite.transform.localScale = new Vector2 (size - transform.position.y * angle, size - transform.position.y * angle);
	}
}
