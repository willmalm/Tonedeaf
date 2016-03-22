using UnityEngine;
using System.Collections;

public class LayerCheck : MonoBehaviour
{
	private GameObject player;
	public float width;
	public float gradient;
	public float x1; //set to highermost x-value
	public float y1; //set to highermost y-value
	public float x2; //set to lower x-value
	public float y2; //set to lower y-value
	public float x;
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
		gradient = (y2 - y1) / (x2 - x1);
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//Debug.DrawLine(new Vector3(x1, y1, transform.position.z), new Vector3(x2, y2, transform.position.z), new Color(1, 0, 0, 1));	
		if ((player.transform.position.x < transform.position.x + width) && (player.transform.position.x > transform.position.x - width))
		{
			if (BelowLine()) 
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, (player.transform.position.z + 1));
			}
			else 
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, (player.transform.position.z - 1));
			}
		}
		if (x1 > x2) 
		{
			width = (x1 - x2) / 2;
		} 
		else
		{
			width = (x2 - x1) / 2;
		}
	}
	private bool BelowLine()
	{
		x = (player.transform.position.y - y1) / gradient + x1;
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