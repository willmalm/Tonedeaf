using UnityEngine;
using System.Collections;

public class OF_Fountain : MonoBehaviour
{
	private ObjectVariables objectVar;
	public bool firstEvent;
	public GameObject censor;
	public GameObject piss;
	// Use this for initialization
	void Start () 
	{
		objectVar = GetComponent<ObjectVariables>();
		firstEvent = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (objectVar.used)
		{
			if (firstEvent)
			{
				firstEvent = false;
                censor.SetActive(false);
			}
			else 
			{
                piss.SetActive(true);
			}
			objectVar.force = 0;
		}
	}
}
