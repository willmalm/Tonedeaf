using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public GameObject playerSprite;
	private PlayerVariables playerVar;
	private Animator animator;
	private Rigidbody2D rb;

	void Start ()
	{
		animator = playerSprite.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		playerVar = GetComponent<PlayerVariables> ();

	}
	
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
}
