using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogFunction : MonoBehaviour {

    //Public variables
    public GameObject dialogText;
    public bool active;

    //Objects
    private GameObject player;
    private GameObject[] items;
    private GameObject[] events;
    private GameObject portrait;

    //Components
    private Text txt;

    private string[] stage;
    private int currentStage;
    private int maxStages;

	void Start () {
        //Dependancy "Text"
        txt = dialogText.GetComponent<Text>();
        //Dependancy "Player"
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        if (active == true)
        {
            if (Input.GetKeyDown("w"))
            {
                if (currentStage == maxStages)
                {
                    deactivate();
                }
                else
                {
                    txt.text = stage[currentStage];
                    if (events[currentStage] != null)
                    {
                        events[currentStage].GetComponent<QuestVariables>().started = true;
                    }
                    if (items[currentStage] != null)
                    {
                        //Add item to inventory
                    }
                    currentStage++;
                }
            }
        }
        else
        {
        }
    }

    public void startDialog(string[] s, GameObject[] g, GameObject[] e, Sprite port)
    {
        GetComponent<UnityEngine.UI.Image>().enabled = true;
        dialogText.GetComponent<Text>().enabled = true;
        portrait.GetComponent<Image>().sprite = port;
        portrait.GetComponent<Image>().enabled = true;
        player.GetComponent<PlayerVariables>().im_event = true;
        currentStage = 0;
        maxStages = s.Length;
        stage = s;
        items = g;
        events = e;
        active = true;
        txt.text = stage[currentStage];
        currentStage++;
    }

    void deactivate()
    {
        active = false;
        currentStage = 0;
        maxStages = 0;
        stage = null;
        GetComponent<UnityEngine.UI.Image>().enabled = false;
        dialogText.GetComponent<UnityEngine.UI.Text>().enabled = false;
        portrait.GetComponent<UnityEngine.UI.Image>().enabled = false;
        player.GetComponent<PlayerVariables>().im_event = false;
    }

}
