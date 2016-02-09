using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Public variables
    public GameObject playerSprite;
    [Header("Idle states")]
    public float idle1_Delay;
    public float idle2_Delay;
    public float reset_Delay;
    [Header("Read-only")]
    public bool movingUp;
    public bool movingDown;
    public float idleTimer;

    //Scripts
    private PlayerVariables playerVar;
    private GridVariables gridVar;
    private SpriteSize playerSize;
    private JensAnimationController playerAnimation;

	void Start ()
	{
        //Dependancy "PlayerVariables", "GridVariables"
		playerVar = GetComponent<PlayerVariables> ();
        gridVar = GetComponent<GridVariables>();

        //Dependancy "Player Sprite"
        playerAnimation = playerSprite.GetComponent<JensAnimationController>();
        playerSize = playerSprite.GetComponent<SpriteSize>();
	}
	
	void Update ()
	{
        //Horizontal movement
        if (Input.GetKey("left"))
		{
            idleTimer = 0;
            transform.position += new Vector3(-playerVar.speed * Time.deltaTime, 0, 0);
            playerSize.direction = 1;
            playerAnimation.speed = new Vector2(1,0);
            playerAnimation.idleAnimation = 0;
        }
        else if (Input.GetKey("right"))
        {
            idleTimer = 0;
            transform.position += new Vector3(playerVar.speed * Time.deltaTime, 0, 0);
            playerSize.direction = -1;
            playerAnimation.speed = new Vector2(1, 0);
            playerAnimation.idleAnimation = 0;
        }
        else
        {
            //Increase timer based on framrate
            idleTimer += Time.deltaTime;

            playerAnimation.speed = new Vector2(0, 0);
            if (idleTimer >= idle1_Delay && idleTimer < idle2_Delay)
            {
                playerAnimation.idleAnimation = 1;
            }
            else if(idleTimer >= idle2_Delay && idleTimer < reset_Delay)
            {
                playerAnimation.idleAnimation = 2;
            }
            else if(idleTimer >= reset_Delay)
            {
                idleTimer = 0;
            }
            else
            {
                playerAnimation.idleAnimation = 0;
            }
        }

        //Vertical movement
        if (Input.GetKey("up") && gridVar.canMoveY)
        {
            gridVar.gridLayer++;
            gridVar.canMoveY = false;
        }
        else if (Input.GetKey("down") && gridVar.canMoveY)
        {
            gridVar.gridLayer--;
            gridVar.canMoveY = false;
        }
        if(gridVar.canMoveY == false)
        {
            idleTimer = 0;
            playerAnimation.speed = new Vector2(1, 0);
        }
    }
}
