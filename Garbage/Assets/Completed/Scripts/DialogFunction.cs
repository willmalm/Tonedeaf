using UnityEngine;
using System.Collections;

public class DialogFunction : MonoBehaviour {

    UnityEngine.UI.Text txt;
    public GameObject dialogText;
    public GameObject player;
    GameObject[] items;
    GameObject[] events;
    public GameObject portrait;
    string[] stage;
    public bool active;
    int currentStage;
    int maxStages;

	void Start () {
        txt = dialogText.GetComponent<UnityEngine.UI.Text>();
	}
	
	void Update () {
        if (active == true)
        {
            if (Input.GetKeyDown("e"))
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
        dialogText.GetComponent<UnityEngine.UI.Text>().enabled = true;
        portrait.GetComponent<UnityEngine.UI.Image>().sprite = port;
        portrait.GetComponent<UnityEngine.UI.Image>().enabled = true;
        player.GetComponent<PlayerVariables>().immobile = true;
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
        player.GetComponent<PlayerVariables>().immobile = false;
    }

}
