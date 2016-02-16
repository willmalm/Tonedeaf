using UnityEngine;
using System.Collections;

public class PivotTest : MonoBehaviour {

    public Vector2 pivot;

    ObjectVariables objectVar;
    public GameObject parent;
    private BeehiveController beehive;

	// Use this for initialization
	void Start()
    {
        beehive = GetComponent<BeehiveController>();
        parent = transform.parent.gameObject;
        try {
            objectVar = transform.parent.gameObject.GetComponent<ObjectVariables>();
        }
        catch
        {
            Debug.Log("fuck you");
        }

    }
	
	// Update is called once per frame
	void Update () {
            if (objectVar.used)
            {
                beehive.dead = true;
            }
    }
}
