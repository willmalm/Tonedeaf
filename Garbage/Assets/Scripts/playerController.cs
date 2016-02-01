using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public GameObject player;
	private PlayerVariables playerVar;
	private Animator animator;
	private Rigidbody2D rb;
	public GameObject collider;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		rb = collider.GetComponent<Rigidbody2D> ();
		playerVar = player.GetComponent<PlayerVariables> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("left"))
		{
			rb.MovePosition(transform.position - transform.right * playerVar.speed * Time.deltaTime);
			animator.SetInteger ("Direction", 1);
		}
		
		if (Input.GetKey ("right"))
		{
			rb.MovePosition(transform.position + transform.right * playerVar.speed * Time.deltaTime);
			animator.SetInteger ("Direction", 3);
		}
		
		if (Input.GetKey ("up"))
		{
			rb.MovePosition(transform.position + transform.up * playerVar.speed * Time.deltaTime);
			animator.SetInteger ("Direction", 2);
		}
		
		if (Input.GetKey ("down"))
		{
			rb.MovePosition(transform.position - transform.up * playerVar.speed * Time.deltaTime);
			animator.SetInteger ("Direction", 0);
		}
	}


	void FixedUpdate()
	{
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		/*if (vertical < 0) 
		{
			animator.SetInteger ("Direction", 1);
		} 
		else if (vertical > 0)
		{
			animator.SetInteger ("Direction", 3);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger ("Direction", 0);
		} 
		else if (horizontal > 0)
		{
			animator.SetInteger	("Direction", 2);
		}*/
	}
}
