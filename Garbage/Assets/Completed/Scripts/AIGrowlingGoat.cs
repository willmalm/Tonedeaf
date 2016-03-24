using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AIGrowlingGoat : MonoBehaviour
{
    private PlayerVariables playerVar;
	private GoatAnimator goat;
	private ObjectVariables goatObject;
	private GameObject[] benchArray;
	private bool actionTaken = false;
	public bool bossActive = false;
	private float timeSinceActionTaken = 0;
	private float timeUntilNextAttack = 0;
	private float timeUntilCanAttack;
	private int lives = 1;
	private AudioSource sound;
	public AudioClip stomp1;
	public AudioClip stomp2;
	public AudioClip scream;
    public float timer = 0;
    private bool firstSound = false;
    private bool secondSound = false;
    private bool thirdSound = false;
    private bool attack = false;
	void Start ()
    {
        playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
		goat = transform.GetChild(0).gameObject.GetComponent<GoatAnimator>();
		goatObject = transform.GetChild(1).gameObject.GetComponent<ObjectVariables>();
		benchArray = GameObject.FindGameObjectsWithTag("OBJECT_bench");
		timeUntilCanAttack = Random.Range(2, 5);
		sound = GetComponent<AudioSource>();
	}
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (sound.isPlaying)
            {
                sound.Stop();
            }
            sound.clip = stomp1;
            sound.Play();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (sound.isPlaying)
            {
                sound.Stop();
            }
            sound.clip = stomp2;
            sound.Play();
        }
        if (bossActive)
		{
			if (actionTaken)
			{
				timeSinceActionTaken += Time.deltaTime;
				if (timeSinceActionTaken > 1f && goat.takeDamage == true)
				{
					goat.takeDamage = false;
					timeSinceActionTaken = 0f;
					timeUntilNextAttack = 0f;
					actionTaken = false;
					timeUntilCanAttack = Random.Range (2, 5);
					Knockdown();
				}
				if ((timeSinceActionTaken > 3.8f) && (timeSinceActionTaken < 4f))
				{
					playerVar.knockdown = true;
					goatObject.toughness = 2;
				}
				else if (timeSinceActionTaken > 5.83f)
				{
					actionTaken = false;
					timeSinceActionTaken = 0f;
					timeUntilNextAttack = 0f;
					goat.attack = false;
					timeUntilCanAttack = Random.Range (2, 5);
				}
			} 
			else
			{
				timeUntilNextAttack += Time.deltaTime;
				if (timeUntilNextAttack > timeUntilCanAttack) 
				{
					Knockdown();
				}
			}
			if (goatObject.used)
			{
				Damaged();
				goatObject.force = 0;
            }
            if (lives == 0)
            {
                goat.dead = true;
                playerVar.im_event = true;
                if (timer > 1.5f)
                {
                    SceneManager.LoadScene(8);
                    bossActive = false;
                }
            }
            timer += Time.deltaTime;
            if (attack == true)
            {
                if (firstSound && timer > 1f)
                {
                    sound.clip = stomp1;
                    sound.Play();
                    firstSound = false;
                }
                if (secondSound && timer > 2.2f)
                {
                    sound.clip = stomp2;
                    sound.Play();
                    secondSound = false;
                }
                if (thirdSound && timer > 3.4f)
                {
                    sound.clip = scream;
                    sound.Play();
                    thirdSound = false;
                }
            }
        }
	}
    public void Knockdown()
    {
		goat.attack = true;
		actionTaken = true;
        timer = 0;
        attack = true;
        firstSound = true;
        secondSound = true;
        thirdSound = true;
    }
	public void Damaged()
	{
		goat.damageTaken = 1;
		goat.takeDamage = true;
		actionTaken = true;
        timer = 0;
        lives--;
		goatObject.toughness = 10000;
		playerVar.im_knockdown = true;
    }
}