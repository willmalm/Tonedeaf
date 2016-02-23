using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour {

    public float posX;
    public float smoothSpeed;
    private GameObject targetObject;
    private float enabledPosX;
    private float disabledPosX;
    private float xPos;
    private bool activated;


	void Start () {
        targetObject = transform.parent.gameObject;
	}

    void Update()
    {
        enabledPosX = targetObject.transform.position.x + posX;
        disabledPosX = targetObject.transform.position.x + posX*5;

        if (activated)
        {
            xPos = Mathf.Lerp(transform.position.x, enabledPosX, smoothSpeed * Time.deltaTime);

        }
        else
        {
            xPos = Mathf.Lerp(transform.position.x, disabledPosX, smoothSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(xPos, transform.position.y, -50);
    }

    public void ChangeState()
    {
        activated = !activated;
    }
}
