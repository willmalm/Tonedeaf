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

	void Start () {
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
    public void LoadScene(int index, bool fade)
    {
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
