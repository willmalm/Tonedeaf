using UnityEngine;
using System.Collections;

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
	private SceneChanger sceneChanger;
	void Start ()
    {
        playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
		goat = transform.GetChild(0).gameObject.GetComponent<GoatAnimator>();
		goatObject = transform.GetChild(1).gameObject.GetComponent<ObjectVariables>();
		benchArray = GameObject.FindGameObjectsWithTag("OBJECT_bench");
		timeUntilCanAttack = Random.Range(2, 5);
	}
	void Update ()
    {
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
		}
	}
    public void Knockdown()
    {
		goat.attack = true;
		actionTaken = true;
    }
	public void Damaged()
	{
		goat.damageTaken = 1;
		goat.takeDamage = true;
		actionTaken = true;
		lives--;
		goatObject.toughness = 10000;
		playerVar.im_knockdown = true;
		if (lives == 0) 
		{
			bossActive = false;
			sceneChanger.LoadScene(5, true, new Vector3(0f, 0f, 0f));
		}
	}
}