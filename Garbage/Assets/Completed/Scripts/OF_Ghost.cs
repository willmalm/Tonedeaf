using UnityEngine;
using System.Collections;

public class OF_Ghost : MonoBehaviour {
	public float timer;
	public float speed;
	public SpriteRenderer fade;

	void Start (){
		fade = GetComponent<SpriteRenderer>();	
	}
	void Update () {
		speed = timer * 2;
		timer += Time.deltaTime;
		fade.color = new Color (1, 1, 1, timer);
		if (timer < 40) {
			transform.position += new Vector3 (0f, 1.8f * Time.deltaTime * speed, 0); 
		}
	}
}
