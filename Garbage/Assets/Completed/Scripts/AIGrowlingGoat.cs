using UnityEngine;
using System.Collections;

public class AIGrowlingGoat : MonoBehaviour
{
    private PlayerVariables playerVar;
	private GoatAnimator goat;
	private ObjectVariables goatObject;
	private bool actionTaken = false;
	public bool bossActive = false;
	private float timeSinceActionTaken;
	private float timeUntilNextAttack;
	private float timeUntilCanAttack;
	private int lives;
	void Start ()
    {
        playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
		goat = transform.GetChild(0).gameObject.GetComponent<GoatAnimator>();
		goatObject = transform.GetChild(1).gameObject.GetComponent<ObjectVariables>();
		timeSinceActionTaken = 0;
		timeUntilNextAttack = 0;
		timeUntilCanAttack = Random.Range(1, 3);
		lives = 3;
	}
	void Update ()
    {
		if (bossActive)
		{
			if (actionTaken) {
				timeSinceActionTaken += Time.deltaTime;
				if (timeSinceActionTaken > 1f && goat.takeDamage == true) {
					goat.takeDamage = false;
					timeSinceActionTaken = 0f;
					actionTaken = false;
					timeUntilCanAttack = Random.Range (1, 3);
				}
				if ((timeSinceActionTaken > 3.8f) && (timeSinceActionTaken < 4f)) {
					playerVar.knockdown = true;
				} else if (timeSinceActionTaken > 5.83f) {
					actionTaken = false;
					timeSinceActionTaken = 0f;
					goat.attack = false;
					timeUntilCanAttack = Random.Range (1, 3);
				}
			} else {
				timeUntilNextAttack += Time.deltaTime;
				if (timeUntilNextAttack > timeUntilCanAttack) {
					Knockdown ();
				}
			}
			if (goatObject.used) {
				Damaged ();
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
	}
}