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
    public bool moving;
    public float idleTimer;

    //Objects
    private GameObject objGridManager;

    //Scripts
    private PlayerVariables playerVar;
    private GridVariables gridVar;
    private SpriteSize playerSize;
    private GridManager gridManager;
    private JensAnimationController playerAnimation;

    private int backUpLayer;

	void Start ()
	{
        //Dependancy "PlayerVariables", "GridVariables"
		playerVar = GetComponent<PlayerVariables> ();
        gridVar = GetComponent<GridVariables>();

        //Dependancy "Player Sprite"
        playerAnimation = playerSprite.GetComponent<JensAnimationController>();
        playerSize = playerSprite.GetComponent<SpriteSize>();

        //Dependancy "GridManager"
        objGridManager = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = objGridManager.GetComponent<GridManager>();

        backUpLayer = 0;
	}
	
	void Update ()
	{
        /*//Horizontal movement
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
        }*/
        if(gridVar.canMoveY == false)
        {
            idleTimer = 0;
            playerAnimation.speed = new Vector2(1, 0);
        }
    }
    public void MoveRight()
    {
        if (transform.position.x < gridManager.layers[gridVar.gridLayer]/2)
        {
            idleTimer = 0;
            transform.position += new Vector3(playerVar.speed * Time.deltaTime, 0, 0);
            playerSize.direction = -1;
            playerAnimation.speed = new Vector2(1, 0);
            playerAnimation.idleAnimation = 0;
        }
        else
        {
            transform.position = new Vector3(gridManager.layers[gridVar.gridLayer] / 2, transform.position.y, transform.position.z);
        }
    }
    public void MoveLeft()
    {
        if (transform.position.x > -gridManager.layers[gridVar.gridLayer]/2)
        {
            idleTimer = 0;
            transform.position += new Vector3(-playerVar.speed * Time.deltaTime, 0, 0);
            playerSize.direction = 1;
            playerAnimation.speed = new Vector2(1, 0);
            playerAnimation.idleAnimation = 0;
        }
        else
        {
            transform.position = new Vector3(-gridManager.layers[gridVar.gridLayer] / 2, transform.position.y, transform.position.z);
        }
    }
    public void MoveUp()
    {
        if (gridVar.canMoveY && transform.position.x >= -gridManager.layers[gridVar.gridLayer + 1] / 2 && transform.position.x <= gridManager.layers[gridVar.gridLayer + 1] / 2)
        {
            backUpLayer = gridVar.gridLayer;
            gridVar.gridLayer++;
            gridVar.canMoveY = false;
        }
    }
    public void MoveDown()
    {
        if (gridVar.canMoveY && transform.position.x >= -gridManager.layers[gridVar.gridLayer-1]/2 && transform.position.x <= gridManager.layers[gridVar.gridLayer-1]/2) 
        {
            backUpLayer = gridVar.gridLayer;
            gridVar.gridLayer--;
            gridVar.canMoveY = false;
        }
    }
    public void Idle()
    {
        if (gridVar.canMoveY)
        {
            //Increase timer based on framrate
            idleTimer += Time.deltaTime;

            playerAnimation.speed = new Vector2(0, 0);
            if (idleTimer >= idle1_Delay && idleTimer < idle2_Delay)
            {
                playerAnimation.idleAnimation = 1;
            }
            else if (idleTimer >= idle2_Delay && idleTimer < reset_Delay)
            {
                playerAnimation.idleAnimation = 2;
            }
            else if (idleTimer >= reset_Delay)
            {
                idleTimer = 0;
            }
            else
            {
                playerAnimation.idleAnimation = 0;
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "objObstacle")
        {
            gridVar.gridLayer = backUpLayer;
            gridVar.canMoveY = false;
        }
    }
}
