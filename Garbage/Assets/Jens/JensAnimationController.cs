using UnityEngine;
using System.Collections;

public class JensAnimationController : MonoBehaviour {
	[HideInInspector]	public Animator animator;
	public Vector2 speed;				//Target speed
	[Range(0f,1f)]
	public float walkSpeedScale = 1;		//Walk speed modifier
	[Range(0f,1f)]
	public float screamStrength;		//Target scream strength

	private float _screamStrength = 0;	//The actual scream strength
	[Range(0,2)]
	public int idleAnimation = 0;		//Idle animation selection

	private float walkSpeedX = 0;		//The actual speed for x
	private float walkSpeedY = 0;		//The actual speed for y

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(animator != null){
			UpdateSpeed();
			UpdateScream();


			animator.SetInteger("idleAnimation", idleAnimation);			//Set idle animation number

			if(_screamStrength > 0) animator.SetBool("screaming", true);	//Set the scream
			else animator.SetBool("screaming", false);
			animator.SetFloat("screamStrength", _screamStrength);

			animator.SetFloat("walkSpeedX", speed.x*walkSpeedScale);					//Set the walking speed for X
		}
	}

	/// <summary>
	/// Sets the current speed. This value is clamped between 0 and 1, where 1 is the max speed.
	/// </summary>
	/// <param name="speed">Speed.</param>
	public void SetMoveSpeed(Vector2 speed){
		speed.x = Mathf.Abs(speed.x);
		speed.y = Mathf.Abs(speed.y);
		this.speed = speed;
	}









	void UpdateSpeed(){			//Lerps the actual speed to the target speed by deltaTime
		speed.x = Mathf.Clamp(Mathf.Abs(speed.x),0f,1f);
		speed.y = Mathf.Clamp(Mathf.Abs(speed.y),0f,1f);
		walkSpeedX = Mathf.Lerp(walkSpeedX,speed.x,Time.smoothDeltaTime*5);
		walkSpeedY = Mathf.Lerp(walkSpeedY,speed.y,Time.smoothDeltaTime*5);

		if(walkSpeedX < 0.05f) walkSpeedX = 0;
		if(walkSpeedY < 0.05f) walkSpeedY = 0;
	}

	void UpdateScream(){		//Lerps the actual scream to the target scream by deltaTime
		_screamStrength = Mathf.Lerp(_screamStrength,screamStrength,Time.smoothDeltaTime*5);
		if(_screamStrength < 0.01f) _screamStrength = 0;
	}
}
























