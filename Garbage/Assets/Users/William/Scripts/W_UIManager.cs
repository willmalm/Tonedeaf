using UnityEngine;
using System.Collections;

public class W_UIManager : MonoBehaviour {

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
