using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    public GameObject UIManager;
    UIManager UI;

    void Start()
    {
        UI = UIManager.GetComponent<UIManager>();
    }
	public void ClickStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void MainMenuPrompt()
    {
        UI.savePrompt.SetActive(true);
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void CancelMainMenu()
    {
        UI.savePrompt.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
