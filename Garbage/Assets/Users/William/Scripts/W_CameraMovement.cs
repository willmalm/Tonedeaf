using UnityEngine;
using System.Collections;

public class W_CameraMovement : MonoBehaviour {

    public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position - new Vector3(0, 0, 90);
	}
}
