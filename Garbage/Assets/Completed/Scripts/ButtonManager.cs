using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

    public GameObject[] buttons;
    public Sprite[] buttonDown;
    public Sprite[] buttonUp;

    public GameObject selected;
    public int currentIndex;

    private AudioSource aud;

	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
        SelectNew(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            SelectNew(-1);
        }
        else if (Input.GetKeyDown("down"))
        {
            SelectNew(1);
        }
        if (Input.GetKeyDown("x"))
        {
            selected.GetComponent<SpriteRenderer>().sprite = buttonDown[currentIndex];
            OnButton();
        }
        else if (Input.GetKeyUp("x"))
        {
            selected.GetComponent<SpriteRenderer>().sprite = buttonUp[currentIndex];
        }
    }

    public void OnButton()
    {
        if(selected == buttons[0])
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else if (selected == buttons[1])
        {
            aud.Play();
        }
        else if (selected == buttons[2])
        {
            Application.Quit();
        }
    }
    public void SelectNew(int dir)
    {
        currentIndex += dir;
        if(currentIndex > 2)
        {
            currentIndex = 2;
        }
        else if(currentIndex < 0)
        {
            currentIndex = 0;
        }
        selected = buttons[currentIndex];
        for (int i = 0; i < 3; i++)
        {
            if(buttons[i] == selected)
            {
                buttons[i].GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            }
            else
            {
                buttons[i].GetComponent<SpriteRenderer>().color = new Color(0.77f, 0.74f, 0.67f, 1);
            }
        }
    }
}
