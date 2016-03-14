using UnityEngine;
using System.Collections;

public class OF_Bench : MonoBehaviour
{
	private ObjectVariables objectVar;
	private PlayerVariables playerVar;
	void Start () 
	{
		objectVar = GetComponent<ObjectVariables>();
		playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
	}
	void Update () 
	{
		if (objectVar.used)
		{
			playerVar.immune = !playerVar.immune;
			playerVar.im_event = playerVar.immune;
			objectVar.used = false;
		}
	}
}
