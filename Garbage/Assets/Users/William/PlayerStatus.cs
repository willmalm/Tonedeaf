using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public PlayerVariables playerVar;
    public float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Immunity(int time)
    {
        float c = timer;
        while((timer - c) < time)
        {
            playerVar.immune = true;
        }
        playerVar.immune = false;
    }
}
