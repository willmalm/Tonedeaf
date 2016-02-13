using UnityEngine;
using System.Collections;

public class PivotTest : MonoBehaviour {

    public Vector2 pivot;

    ObjectVariables objectVar;
    public GameObject parent;

	// Use this for initialization
	void Start()
    {
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
        try{
            if (objectVar.used)
            {
                if (transform.position.y <= transform.parent.gameObject.transform.position.y)
                {
                    transform.position = transform.parent.gameObject.transform.position;
                }
                else
                {
                    transform.position += new Vector3(0, -4 * Time.deltaTime, 0);
                }
            }
        }
        catch
        {
            Debug.Log("Failed to assign parent");
        }
    }
}
