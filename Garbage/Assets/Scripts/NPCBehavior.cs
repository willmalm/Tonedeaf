using UnityEngine;
using System.Collections;

public class NPCBehavior : MonoBehaviour {

    public bool usingWalk;
    [Space(10)]
    public int speed;
    [Header("Distance")]
    [Range(0, 10)]
    public int minDistance;
    [Range(0, 10)]
    public int maxDistance;
    [Header("Delay")]
    [Range(0, 10)]
    public int minDelay;
    [Range(0, 10)]
    public int maxDelay;
    [Range(0, 10)]
    public int idleDelay;
    [Header("Read-only")]
    public float timer;
    public float distance;
    public float delay;
    public float currentDistance;
    [Space(10)]
    public bool walking;
    public bool movedRight;
    public bool active;

    float relDistanceRight;
    float relDistanceLeft;

    bool timerPaused = false;
    bool startUp = true;

    void Start () {
        relDistanceRight = transform.position.x + maxDistance;
        relDistanceLeft = transform.position.x - maxDistance;
	}

	void Update () {
        if (active && usingWalk)
        {
            if (timerPaused == false)
            {
                timer += Time.deltaTime;
            }
            if (startUp)
            {
                distance = minDistance + Random.value * (maxDistance - minDistance);
                delay = minDelay + Random.value * (maxDelay - minDelay);
                startUp = false;
            }
            if (timer >= delay)
            {
                walking = true;
            }
            if (timer >= idleDelay && walking == false)
            {
                timerPaused = true;
                //idle animation
                timerPaused = false;

            }
            if (movedRight && walking)
            {
                currentDistance += speed * Time.deltaTime;
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (currentDistance >= distance || transform.position.x <= relDistanceLeft)
                {
                    currentDistance = 0;
                    timer = 0;
                    movedRight = false;
                    walking = false;
                    startUp = true;
                }
            }
            else if (movedRight == false && walking)
            {
                currentDistance += speed * Time.deltaTime;
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (currentDistance >= distance || transform.position.x >= relDistanceRight)
                {
                    currentDistance = 0;
                    timer = 0;
                    movedRight = true;
                    walking = false;
                    startUp = true;
                }
            }
        }

    }
}
