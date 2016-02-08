using UnityEngine;
using System.Collections;

public class W_Speech : MonoBehaviour {

    [Range(0,10)]
    public int range;
    public GameObject speech;
    public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (player.transform.position.x > transform.position.x-range && player.transform.position.x < transform.position.x + range)
        {
            speech.SetActive(true);
        }
        else
        {
            speech.SetActive(false);
        }
	}
}
