using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pauseWindow;
    public GameObject savePrompt;
    public bool pauseBool = true;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseWindow.SetActive(pauseBool);
            pauseBool = !pauseBool;
        }
	}
}
