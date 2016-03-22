using UnityEngine;
using System.Collections;

public class OF_Chains : MonoBehaviour {
	ObjectVariables var;
	SpriteRenderer sprite;
	public Sprite chains;
	public GameObject collider;

	void Start () {
		var = GetComponent<ObjectVariables>();
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (var.used){
			collider.SetActive(true);
		gameObject.SetActive (false);
		}
	}
}
