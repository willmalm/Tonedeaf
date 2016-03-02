using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

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
    public  bool activated = false;
    private float xPos;
    private float yPos;
    private bool shaking;
    public bool playerImmobile;



    public float rangeUp;
    public float rangeRight;

    private float rUp;
    private float rRight;

    private float posUp;
    private float posDown;
    private float posRight;
    private float posLeft;

    // Use this for initialization
    void Start()
    {
        rUp = 0;
        rRight = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
                rUp = 0;
                rRight = 0;
                player.GetComponent<PlayerVariables>().immobile = true;
                activated = true;
            }
            rUp += shakeSpeed * Time.deltaTime;
            rRight += shakeSpeed * Time.deltaTime;
            if(rUp >= rangeUp)
            {
                rUp = rangeUp;
            }
            if(rRight >= rangeRight)
            {
                rRight = rangeRight;
            }
            posUp = cameraRef.transform.position.y + rUp;
            posDown = cameraRef.transform.position.y - rUp;
            posRight = cameraRef.transform.position.x + rRight;
            posLeft = cameraRef.transform.position.x - rRight;
            if(posLeft < limitLeft) {
                posLeft = limitLeft;
            }
            if(posRight > limitRight)
            {
                posRight = limitRight;
            }
            if(posUp > limitUp)
            {
                posUp = limitUp;
            }
            if(posDown < limitDown)
            {
                posDown = limitDown;
            }
            objCamera.transform.position = new Vector3(Random.Range(posLeft, posRight), Random.Range(posDown, posUp), objCamera.transform.position.z);
        }
        else if (!shaking)
        {
            if (activated == true && playerImmobile)
            {
                activated = false;
            }
            activated = false;
            rUp -= shakeSpeed * Time.deltaTime;
            rRight -= shakeSpeed * Time.deltaTime;
            if (rUp <= 0 && rRight <= 0)
            {
                objCamera.transform.position = cameraRef.transform.position;
                player.GetComponent<PlayerVariables>().immobile = false;
            }
            else
            {
                posUp = cameraRef.transform.position.y + rUp;
                posDown = cameraRef.transform.position.y - rUp;
                posRight = cameraRef.transform.position.x + rRight;
                posLeft = cameraRef.transform.position.x - rRight;
                if (posLeft < limitLeft)
                {
                    posLeft = limitLeft;
                }
                else if (posRight > limitRight)
                {
                    posRight = limitRight;
                }
                else if (posUp > limitUp)
                {
                    posUp = limitUp;
                }
                else if (posDown < limitDown)
                {
                    posDown = limitDown;
                }
                objCamera.transform.position = new Vector3(Random.Range(posLeft, posRight), Random.Range(posDown, posUp), objCamera.transform.position.z);
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
