using UnityEngine;
using System.Collections;

public class BeehiveController : MonoBehaviour {
	[HideInInspector]public Animator anim;
	public bool fuckYou = false;
	public bool dead = false;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("destroyed",dead);
		anim.SetBool("fuckYou",fuckYou);
	}
}
