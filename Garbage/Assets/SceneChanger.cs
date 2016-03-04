using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public bool fade_on_start;

    private float timer;
    private bool using_timer;
    private int sceneIndex;

    private GameObject obj_fade;
    private Fade fade;

    private GameObject obj_keeper;
    private Keeper keeper;

    Vector3 player_position;

	void Start () {
        obj_keeper = GameObject.FindGameObjectWithTag("GLOBAL_keeper");
        keeper = obj_keeper.GetComponent<Keeper>();
        obj_fade = GameObject.FindGameObjectWithTag("GLOBAL_fade");
        fade = obj_fade.GetComponent<Fade>();
        if (fade_on_start)
        {
            fade.EndFade();
        }
	}
	
	void Update () {
        if (using_timer)
        {
            if(timer == 0)
            {
                fade.BeginFade();
            }
            timer += Time.deltaTime;
            if(timer >= fade.fade_time)
            {
                keeper.player_position = player_position;
                SceneManager.LoadScene(sceneIndex);
                using_timer = false;
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
	}
    public void LoadScene(int index, bool fade, Vector3 plPos)
    {
        player_position = plPos;
        if (fade)
        {
            sceneIndex = index;
            using_timer = true;
            
        }
        else
        {
            SceneManager.LoadScene(index);
        }
    }
}
