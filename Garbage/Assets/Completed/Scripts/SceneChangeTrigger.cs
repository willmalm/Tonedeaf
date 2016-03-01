using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneName;
    public bool canEnter = false;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "plInteract")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                SceneManager.LoadScene(sceneName);
            }



        }
    }
        void OnTriggerEnter2D(Collider2D col)
        
    {
        
            if (canEnter == true && col.tag == "plInteract")
            {
                SceneManager.LoadScene(sceneName);
            }

           
        }

    }
   

