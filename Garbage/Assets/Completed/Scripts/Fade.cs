using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public float speed;
    public float duration;
    private bool fade;
    private float timer;
    private float timer_black;
    private bool rising = true;

    SpriteRenderer sprite;

	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }

	void Update () {
        if (fade)
        {
            if (rising) {
                timer += speed * Time.deltaTime;
                sprite.color = new Color(1f, 1f, 1f, timer);
                if(timer >= 1)
                {
                    timer_black += Time.deltaTime;
                    if (timer_black >= duration)
                    {
                        timer_black = 0;
                        timer = 1;
                        rising = false;
                    }
                }
            }
            else if (!rising)
            {
                timer -= speed * Time.deltaTime;
                sprite.color = new Color(1f, 1f, 1f, timer);
                if(timer <= 0)
                {
                    timer = 0;
                    rising = true;
                    fade = false;
                }
            }
        }
	}
    public void UseFade()
    {
        fade = true;
    }
}
