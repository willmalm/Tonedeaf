using UnityEngine;
using System.Collections;

public class OF_PartyGhost : MonoBehaviour 
{
	private SpriteRenderer ghostSprite;
	public Sprite[] framesArray;
	public int delay;
	public int count;

	void Start () 
	{
		ghostSprite = GetComponent<SpriteRenderer>();
		transform.localScale += new Vector3 (1.1f, 1.1f, 1f);
	}
	

	void Update () 
	{
		delay++;
		if (delay % 5 == 0)
		{
			count++;
			if (count == framesArray.Length)
			{
				count = 0;
				delay = 0;
			}
			ghostSprite.sprite = framesArray[count];
		}
	}
}
