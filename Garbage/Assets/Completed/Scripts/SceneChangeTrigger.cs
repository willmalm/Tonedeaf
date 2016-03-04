using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeTrigger : MonoBehaviour
{
    public int sceneIndex;
    public bool canEnter = false;

    private GameObject obj_sceneChanger;
    private SceneChanger sceneChanger;
    public Vector3 player_position;

    private void Start()
    {
        obj_sceneChanger = GameObject.FindGameObjectWithTag("GLOBAL_sceneChanger");
        sceneChanger = obj_sceneChanger.GetComponent<SceneChanger>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "PLAYER_interact")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                sceneChanger.LoadScene(sceneIndex, true, player_position);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)       
    {
        
            if (canEnter == true && col.tag == "PLAYER_interact")
            {
                sceneChanger.LoadScene(sceneIndex, true, player_position);
            }
           
        }

    }
   

