using UnityEngine;
using System.Collections;

public class OF_Grave : MonoBehaviour
{
	public GameObject ghost;

	private bool instantiate = true;
	private ObjectVariables var_grave;

	void Start ()
	{
		var_grave = GetComponent<ObjectVariables>();
	}
	void Update ()
	{
		if (var_grave.used)
		{
			if (instantiate) 
			{
				Instantiate (ghost, transform.position + new Vector3(-1, 0, -10), Quaternion.identity);
				instantiate = false;
			}
		}
	}
}