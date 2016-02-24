using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    GameObject player;
    public int smoothSpeed;
    public float shakeRange;
    public float shakeSpeed;
    public float limitLeft;
    public float limitRight;
    public float limitUp;
    public float limitDown;

    public GameObject objCamera;
    public GameObject cameraRef;
    private bool direction;

    private float speed;
    private bool activated;
    private float xPos;
    private float yPos;
    private bool shaking;
    private bool playerImmobile;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!activated)
        {
            xPos = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothSpeed * Time.deltaTime);
            yPos = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(xPos, yPos, -100);

            if (transform.position.x <= limitLeft)
            {
                transform.position = new Vector3(limitLeft, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= limitRight)
            {
                transform.position = new Vector3(limitRight, transform.position.y, transform.position.z);
            }
            if (transform.position.y <= limitDown)
            {
                transform.position = new Vector3(transform.position.x, limitDown, transform.position.z);
            }
            else if (transform.position.y >= limitUp)
            {
                transform.position = new Vector3(transform.position.x, limitUp, transform.position.z);
            }
        }
        if (shaking)
        {
            if (activated == false && playerImmobile)
            {
                player.GetComponent<PlayerVariables>().immobile = true;
            }
            activated = true;
            speed += shakeSpeed * Time.deltaTime;
            if (speed >= shakeSpeed)
            {
                speed = shakeSpeed;
            }
            if (direction)
            {
                objCamera.transform.position = Vector3.MoveTowards(objCamera.transform.position, new Vector3(cameraRef.transform.position.x + shakeRange, objCamera.transform.position.y, objCamera.transform.position.z), speed * Time.deltaTime);
                if (objCamera.transform.position.x >= cameraRef.transform.position.x + shakeRange)
                {
                    direction = false;
                }
            }
            else if (direction == false)
            {
                objCamera.transform.position = Vector3.MoveTowards(objCamera.transform.position, new Vector3(cameraRef.transform.position.x - shakeRange, objCamera.transform.position.y, objCamera.transform.position.z), speed * Time.deltaTime);
                if (objCamera.transform.position.x <= cameraRef.transform.position.x - shakeRange)
                {
                    direction = true;
                }
            }
        }
        else if (!shaking)
        {
            speed -= shakeSpeed * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
                objCamera.transform.position = Vector3.MoveTowards(objCamera.transform.position, new Vector3(cameraRef.transform.position.x, objCamera.transform.position.y, objCamera.transform.position.z), shakeSpeed * Time.deltaTime);
                if (playerImmobile && objCamera.transform.position.x == cameraRef.transform.position.x)
                {
                    activated = false;
                    objCamera.transform.position = new Vector3(cameraRef.transform.position.x, objCamera.transform.position.y, objCamera.transform.position.z);
                    player.GetComponent<PlayerVariables>().immobile = false;
                }

            }
            if (activated)
            {
                if (direction)
                {
                    objCamera.transform.position = Vector3.MoveTowards(objCamera.transform.position, new Vector3(cameraRef.transform.position.x + shakeRange, objCamera.transform.position.y, objCamera.transform.position.z), speed * Time.deltaTime);
                    if (objCamera.transform.position.x >= cameraRef.transform.position.x + shakeRange)
                    {
                        direction = false;
                    }
                }
                else if (direction == false)
                {
                    objCamera.transform.position = Vector3.MoveTowards(objCamera.transform.position, new Vector3(cameraRef.transform.position.x - shakeRange, objCamera.transform.position.y, objCamera.transform.position.z), speed * Time.deltaTime);
                    if (objCamera.transform.position.x <= cameraRef.transform.position.x - shakeRange)
                    {
                        direction = true;
                    }
                }
            }
        }
    }
    public void ScreenShake(bool im)
    {
        shaking = true;
        playerImmobile = im;
        
    }
    public void StopShake(bool im)
    {
        shaking = false;
        playerImmobile = im;
    }
}
