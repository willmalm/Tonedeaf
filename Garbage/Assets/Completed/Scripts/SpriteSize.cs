using UnityEngine;
using System.Collections;

public class SpriteSize : MonoBehaviour {

    //Public variables
    public float sizeX, sizeY;
    public float angle;
    public float acceleration;
    [Range(1,-1)]
    public float direction;

    void Update ()
	{
        //Changes object scale based on curent layer and modifiable values
		transform.localScale = new Vector3 (Mathf.Pow((sizeX - transform.position.y * angle), acceleration) * direction, Mathf.Pow((sizeY - transform.position.y * angle), acceleration), 1);
	}
}
