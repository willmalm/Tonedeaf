using UnityEngine;
using System.Collections;

public class Nazi_Controller : MonoBehaviour {
	Animator anim;

	public bool knockBack 	= false;
	public bool running 	= false;
	[Range(0,1)]
	public float runSpeed = 1;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(anim != null){
			anim.SetBool("knockback", knockBack);
			if(knockBack) knockBack = false;

			anim.SetBool("running", running);
			anim.SetFloat("speed", runSpeed);
		}
	}
}
