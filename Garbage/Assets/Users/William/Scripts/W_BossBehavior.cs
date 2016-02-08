using UnityEngine;
using System.Collections;

public class W_BossBehavior : MonoBehaviour {

    public int darkness;
    public GameObject[] stages;
    StageVariables stageVar;
    int currentStage = 0;
    bool startup = true;

    void Start () {
	
	}

	void Update () {
        checkStage();
	}

    void checkStage()
    {
        if (currentStage == 0)
        {
            if (startup)
            {
                stageVar = stages[currentStage].GetComponent<StageVariables>();
                startup = false;
            }
            if (darkness <= stageVar.startup_darkness && darkness > stageVar.end_darkness)
            {
                stageVar.activated = true;
            }
            else
            {
                stageVar.activated = false;
                currentStage++;
                startup = true;
            } 
        }
        if (currentStage < stages.Length)
        {
            //end of battle
        }
    }
}
