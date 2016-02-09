using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    public GameObject UIManager;
    private UIManager UI;

    void Start()
    {
        //Dependancy "UIManager"
        UI = UIManager.GetComponent<UIManager>();
    }
    //Starts the game
	public void ClickStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    //Activate SavePrompt
    public void MainMenuPrompt()
    {
        UI.savePrompt.SetActive(true);
    }
    //Returns to main menu
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    //Deactivate SavePrompt
    public void CancelMainMenu()
    {
        UI.savePrompt.SetActive(false);
    }
    //Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
