using UnityEngine;
using System.Collections;

public class OF_GrowlingGoatStart : MonoBehaviour
{
	private ObjectVariables objectVar;
	private AIGrowlingGoat growlingGoat;
	private PlayerVariables playerVar;
	private Collider2D collider;
	void Start () 
	{
		objectVar = GetComponent<ObjectVariables>();
		growlingGoat = GetComponent<AIGrowlingGoat>();
		playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
		collider = GetComponent<Collider2D>();
	}
	void Update ()
	{
		if (objectVar.used)
		{
			growlingGoat.Knockdown();
			growlingGoat.bossActive = true;
			playerVar.im_knockdown = true;
			collider.enabled = false;
			objectVar.used = false;
			playerVar.horizontal_speed -= 0.75f;
			playerVar.vertical_speed -= 0.25f;
		}
	}
}
