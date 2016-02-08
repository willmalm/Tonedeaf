using UnityEngine;
using System.Collections;

public class W_PlayerSprite : MonoBehaviour {

    SpriteRenderer sprite;
    public float angle;

	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        sprite.transform.localScale = new Vector2(angle - transform.position.y, angle - transform.position.y);
    }
}
