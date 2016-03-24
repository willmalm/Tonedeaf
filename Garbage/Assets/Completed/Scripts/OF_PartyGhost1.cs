using UnityEngine;
using System.Collections;

public class OF_PartyGhost1 : MonoBehaviour {
    public GameObject ghost;
    ObjectVariables var;
	// Use this for initialization
	void Start () {
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        if (var.used)
        {
            ghost.SetActive(true);
            //ghost.GetComponent<VideoSequence>().Play();
            var.force = 0;
            var.toughness = 1000000;
            var.used = false;
        }
	}
}
