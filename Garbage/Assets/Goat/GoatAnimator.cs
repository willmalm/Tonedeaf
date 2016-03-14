using UnityEngine;
using System.Collections;

public class GoatAnimator : MonoBehaviour {
	[HideInInspector]public Animator anim;
	public bool attack = false;
	public bool takeDamage = false;
	[Range(0,1)]public float damageTaken = 1;

	public Material glowMaterial;
	[HideInInspector]public float scream = 0;
	private float glow = 0;
	private GameObject boneScream, boneGlow, boneSmash;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();

		boneScream 	= GetName("Scream");
		boneGlow 	= GetName("GlowStrength");
		boneSmash 	= GetName("GroundSmash");
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("attack",attack);
		anim.SetFloat("damageTaken",damageTaken);
		anim.SetBool("knockBack",takeDamage);

		scream 	= Mathf.Clamp(boneScream.transform.localPosition.z,0f,1f);
		glow 	= Mathf.Clamp(boneGlow.transform.localPosition.z,0f,1f);
		Color temp = glowMaterial.GetColor("_TintColor");
		temp.a = glow*glow*0.5f;
		glowMaterial.SetColor("_TintColor",temp);
	}



	GameObject GetName(string name){
		Transform[] trans = gameObject.GetComponentsInChildren<Transform>();
		for(int i = 0; i < trans.Length;i++){
			if(trans[i].name == name) return trans[i].gameObject;
		}
		return null;
	}
}
