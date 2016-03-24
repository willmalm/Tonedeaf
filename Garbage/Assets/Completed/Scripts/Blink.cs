using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    public float timer = 0;
    private SpriteRenderer spriteRenderer;
    private bool increaseTimer = true;
	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (increaseTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (timer > 0.95f)
        {
            increaseTimer = false;
        }
        else if (timer < 0.05f)
        {
            increaseTimer = true;
        }
        spriteRenderer.color = new Color(0.5f + timer, timer - 0.3f, timer - 0.3f, 1f);
	}
}
