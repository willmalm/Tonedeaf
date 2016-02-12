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
        //Dependency "PlayerVariables", "GridVariables"
		playerVar = GetComponent<PlayerVariables> ();
        gridVar = GetComponent<GridVariables>();

        //Dependency "Player Sprite"
        playerAnimation = playerSprite.GetComponent<JensAnimationController>();
        playerSize = playerSprite.GetComponent<SpriteSize>();

        //Dependency "GridManager"
        objGridManager = GameObject.FindGameObjectWithTag("GridManager");
        gridManager = objGridManager.GetComponent<GridManager>();

        backUpLayer = 0;
	}

    void Update()
    { }
        
    public void MoveRight()
    {
        
            idleTimer = 0;
            transform.position += new Vector3(playerVar.horizontal_speed * Time.deltaTime, 0, 0);
            playerSize.direction = -1;
            playerAnimation.speed = new Vector2(1, 0);
            playerAnimation.idleAnimation = 0;
       
    }
    public void MoveLeft()
    {
            idleTimer = 0;
            transform.position += new Vector3(-playerVar.horizontal_speed *  Time.deltaTime, 0, 0);
            playerSize.direction = 1;
            playerAnimation.speed = new Vector2(1, 0);
            playerAnimation.idleAnimation = 0;
    }
    public void MoveUp()
    {
        idleTimer = 0;
        transform.position += new Vector3(0, playerVar.vertical_speed * Time.deltaTime, 0);
        playerAnimation.speed = new Vector2(1, 0);
        playerAnimation.idleAnimation = 0;


    }
    public void MoveDown()
    {
        idleTimer = 0;
        transform.position += new Vector3(0, -playerVar.vertical_speed * Time.deltaTime, 0);
        playerAnimation.speed = new Vector2(1, 0);
        playerAnimation.idleAnimation = 0;
    }
    public void Idle()
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
