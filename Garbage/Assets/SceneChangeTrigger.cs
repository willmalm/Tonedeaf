using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeTrigger : MonoBehaviour {

    public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(sceneName);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
