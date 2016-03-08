using UnityEngine;
using System.Collections;

public class OF_Scene : MonoBehaviour {

    public int sceneIndex;

    private GameObject obj_sceneChanger;
    private SceneChanger sceneChanger;
    public Vector3 player_position;
    ObjectVariables var;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();

        obj_sceneChanger = GameObject.FindGameObjectWithTag("GLOBAL_sceneChanger");
        sceneChanger = obj_sceneChanger.GetComponent<SceneChanger>();
    }
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            sceneChanger.LoadScene(sceneIndex, true, player_position);
            var.used = false;
        }
	}
}
