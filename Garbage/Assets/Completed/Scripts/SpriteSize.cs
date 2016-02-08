using UnityEngine;
using System.Collections;

public class SpriteSize : MonoBehaviour {

	public float angle;
	public float sizeY;
    public float sizeX;
    public float direction;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
	{
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localScale = new Vector2 ((sizeX - transform.position.y * angle)*direction, (sizeY - transform.position.y * angle));
	}
}
