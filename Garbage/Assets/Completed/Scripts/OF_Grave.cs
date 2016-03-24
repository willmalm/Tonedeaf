using UnityEngine;
using System.Collections;

public class OF_Grave : MonoBehaviour
{
	public GameObject ghost;
    public GameObject key;
	private bool instantiate = true;
	private ObjectVariables var_grave;
    private AudioSource aud;
	void Start ()
	{
		var_grave = GetComponent<ObjectVariables>();
        aud = GetComponent<AudioSource>();
	}
	void Update ()
	{
		if (var_grave.used)
		{
			if (instantiate) 
			{
				Instantiate (ghost, transform.position + new Vector3(-1, 0, -10), Quaternion.identity);
                aud.Play();
				instantiate = false;
                if(key != null)
                {
                    Instantiate(key, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                }
			}
		}
	}
}