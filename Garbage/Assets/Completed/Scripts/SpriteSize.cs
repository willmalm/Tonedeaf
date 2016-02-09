using UnityEngine;
using System.Collections;

public class SpriteSize : MonoBehaviour {

	public float angle;
	public float sizeY;
    public float sizeX;
    public float direction;
    public float angleMultiplier;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
	{
		//sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localScale = new Vector3 (Mathf.Pow(((sizeX - transform.position.y * angle)), angleMultiplier) * direction, Mathf.Pow(((sizeY - transform.position.y * angle)), angleMultiplier), 1);
	}
}
