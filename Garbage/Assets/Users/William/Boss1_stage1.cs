using UnityEngine;
using System.Collections;

public class Boss1_stage1 : MonoBehaviour {

    public StageVariables stageVar;
    public float screech_timer;
    public float screech_cooldown;
    public float screech_duration;
    public float screech_speed;
    public int screech_damage;
    bool startup = true;
    void Start () {
	
	}

	void Update () {
        screech_timer += Time.deltaTime;

	    if (stageVar.activated)
        {
            //Events on stage start
            if (startup)
            {
                startup = false;
            }
            //Continuous events
            if (screech_timer > screech_cooldown)
            {
                Screech();

            }
            if (screech_timer > screech_duration + screech_cooldown)
            {
                screech_timer = 0;
                stopScreech();
            }
        }
    }
    void Screech()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().radius = (screech_timer - screech_cooldown) * screech_speed;
    }

    void stopScreech()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().radius = 0;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<PlayerVariables>().immune == false)
            {
                col.gameObject.GetComponent<PlayerVariables>().currentHealth -= screech_damage;
                col.gameObject.GetComponent<PlayerVariables>().knockdown = true;
                Debug.Log("Player took damage and was knocked down");
            }
        }
    }

}
