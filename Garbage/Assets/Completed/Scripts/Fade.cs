using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public float fade_time;

    private bool fade;
    private float timer;
    private bool rising = true;

    private SpriteRenderer sprite;

	private void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

	private void Update ()
    {
        if (fade)
        {
            if (rising)
            {
                timer += Time.deltaTime;
                sprite.color = new Color(1f, 1f, 1f, timer * 1/fade_time);
                if(timer >= fade_time)
                {
                    timer = fade_time;
                    fade = false;
                }
            }
            else if (!rising)
            {
                timer -= Time.deltaTime;
                sprite.color = new Color(1f, 1f, 1f, timer * 1/fade_time);
                if(timer <= 0)
                {
                    timer = 0;
                    fade = false;
                }
            }
        }
	}
    public void BeginFade()
    {
        fade = true;
        timer = 0;
        rising = true;
    }
    public void EndFade()
    {
        fade = true;
        timer = fade_time;
        rising = false;
    }
}
