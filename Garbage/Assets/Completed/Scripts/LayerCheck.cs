using UnityEngine;
using System.Collections;

public class LayerCheck : MonoBehaviour
{
	private GameObject player;
	private float width;
	public float x1;
	public float x2;
	public float y1;
	public float y2;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (x1 > x2) 
		{
			width = (x1 - x2) / 2;
		} 
		else
		{
			width = (x2 - x1) / 2;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if ((player.transform.position.x < transform.position.x + width) && (player.transform.position.x > transform.position.x - width))
		{
			if (BelowLine()) 
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 1);
			}
			else 
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 1);
			}
		}
	}
	private bool BelowLine()
	{
		float gradient = (y2 - y1) / (x2 - x1);
		y1 = -x1 * gradient;
		x1 = 0;
		float x = (player.transform.position.y - y1) / gradient;
		if (x1 < x2)
		{
			if (player.transform.position.x < x)
			{
				return true;
			}
		} 
		else
		{
			if (player.transform.position.x > x)
			{
				return true;
			}
		}
		return false;
	}
}