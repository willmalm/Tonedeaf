using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    [Range(0,10)]
    public int range;
    public GameObject speech;
    GameObject player;
    GridVariables plGridVar;
    GridVariables gridVar;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gridVar = GetComponent<GridVariables>();
        plGridVar = player.GetComponent<GridVariables>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x > transform.position.x-range && player.transform.position.x < transform.position.x + range && plGridVar.gridLayer == gridVar.gridLayer)
        {
            speech.SetActive(true);
        }
        else
        {
            speech.SetActive(false);
        }
	}
}
