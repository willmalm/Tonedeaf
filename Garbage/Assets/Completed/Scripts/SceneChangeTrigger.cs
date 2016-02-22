using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeTrigger : MonoBehaviour
{
    public string sceneName;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plInteract")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
