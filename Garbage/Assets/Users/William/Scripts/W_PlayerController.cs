using UnityEngine;
using System.Collections;

public class W_PlayerController : MonoBehaviour {

    public GameObject playerSprite;
    public GameObject gridObject;
	private PlayerVariables playerVar;
	private Animator animator;
	private Rigidbody2D rb;

    public bool movingUp;
    public bool movingDown;

	void Start ()
	{
		animator = playerSprite.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		playerVar = GetComponent<PlayerVariables> ();

	}
	
	void Update ()
	{
        if (movingUp)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, gridObject.transform.position.y, 0), playerVar.speed* Time.deltaTime);
            transform.position += new Vector3(0, playerVar.speed * Time.deltaTime, 0);
            if (transform.position.y >= gridObject.transform.position.y)
            {
                movingUp = false;
                transform.position = new Vector3(transform.position.x, gridObject.transform.position.y, 0);
                gridObject.GetComponent<GridMovement>().canMove = true;
            }
        }
        if (movingDown)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, gridObject.transform.position.y, 0), playerVar.speed *Time.deltaTime);
            transform.position -= new Vector3(0, playerVar.speed * Time.deltaTime, 0);
            if (transform.position.y <= gridObject.transform.position.y)
            {
                movingDown = false;
                transform.position = new Vector3(transform.position.x, gridObject.transform.position.y, 0);
                gridObject.GetComponent<GridMovement>().canMove = true;
            }
        }
        if (Input.GetKey ("left"))
		{
			rb.MovePosition(transform.position - transform.right * playerVar.speed * Time.deltaTime);
			animator.SetInteger ("Direction", 1);
		}

        if (Input.GetKey("right"))
        {
            rb.MovePosition(transform.position + transform.right * playerVar.speed * Time.deltaTime);
            animator.SetInteger("Direction", 3);
        }
        if (Input.GetKey("up"))
        {
            animator.SetInteger("Direction", 2);
        }
        if (Input.GetKey("down"))
        {
            animator.SetInteger("Direction", 0);
        }
    }
}
