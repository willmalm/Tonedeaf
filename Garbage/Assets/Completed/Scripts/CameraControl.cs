using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour
{
    [System.Serializable]
    public class UIElement
    {
        public GameObject obj;
        public Vector3 position;
        public Vector3 scale;
    }

    //Public
    [Header("Camera settings")]
    public GameObject target;
    public float cameraOffset;
    public int cameraSpeed;
    [Range(0.1f, 1f)]
    public float zoom;
    public bool updateZoom;
    
    [Header("Limits")]
    public float limitLeft;
    public float limitRight;
    public float limitUp;
    public float limitDown;

    [Header("Screenshake")]
    public float shakeSpeed;
    public float rangeUp;
    public float rangeRight;

    [Header("User Interface")]
    public UIElement[] elements;

    [Header("References")]
    public GameObject cameraParent;
    public GameObject objCamera;
    public GameObject cameraRef;

    //Private
    private float speed;
    private bool activated = false;
    private float xPos;
    private float yPos;
    private bool shaking;

    private float rUp;
    private float rRight;

    private float posUp;
    private float posDown;
    private float posRight;
    private float posLeft;

    private bool playerImmobile;

    private GameObject player;
    private Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        cameraRef.transform.position += new Vector3(0, cameraOffset, 0);
        mainCamera = objCamera.GetComponent<Camera>();
        mainCamera.orthographicSize = 20*(1 - zoom);
        rUp = 0;
        rRight = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (updateZoom)
        {
            mainCamera.orthographicSize = 20 * (1 - zoom);
            UpdateUI();
        }
        if (!activated)
        {
            xPos = Mathf.Lerp(cameraParent.transform.position.x, target.transform.position.x, cameraSpeed * Time.deltaTime);
            yPos = Mathf.Lerp(cameraParent.transform.position.y, target.transform.position.y + cameraOffset, cameraSpeed * Time.deltaTime);
            cameraParent.transform.position = new Vector3(xPos, yPos, -100);

            if (cameraParent.transform.position.x <= limitLeft)
            {
                cameraParent.transform.position = new Vector3(limitLeft, cameraParent.transform.position.y, cameraParent.transform.position.z);
            }
            else if (cameraParent.transform.position.x >= limitRight)
            {
                cameraParent.transform.position = new Vector3(limitRight, cameraParent.transform.position.y, cameraParent.transform.position.z);
            }
            if (cameraParent.transform.position.y <= limitDown)
            {
                cameraParent.transform.position = new Vector3(cameraParent.transform.position.x, limitDown, cameraParent.transform.position.z);
            }
            else if (cameraParent.transform.position.y >= limitUp)
            {
                cameraParent.transform.position = new Vector3(cameraParent.transform.position.x, limitUp, cameraParent.transform.position.z);
            }
        }
        if (shaking)
        {
            if (activated == false && playerImmobile)
            {
                rUp = 0;
                rRight = 0;
                player.GetComponent<PlayerVariables>().im_screech = true;
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
            if(posUp > limitUp+cameraOffset)
            {
                posUp = limitUp+cameraOffset;
            }
            if(posDown < limitDown + cameraOffset)
            {
                posDown = limitDown+cameraOffset;
            }
            objCamera.transform.position = new Vector3(Random.Range(posLeft, posRight), Random.Range(posDown, posUp), objCamera.transform.position.z);
        }
        else if (!shaking)
        {
            
            rUp -= shakeSpeed * Time.deltaTime;
            rRight -= shakeSpeed * Time.deltaTime;
            if (rUp <= 0 && rRight <= 0)
            {
                objCamera.transform.position = cameraRef.transform.position;
                if (activated == true && playerImmobile)
                {
                    activated = false;
                    player.GetComponent<PlayerVariables>().im_screech = false;
                }
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
    private void UpdateUI()
    {
        for(int i = 0; i < elements.Length; i++)
        {
            elements[i].obj.transform.position = new Vector3(objCamera.transform.position.x + elements[i].position.x * (1 - zoom), objCamera.transform.position.y + elements[i].position.y * (1 - zoom), objCamera.transform.position.z + elements[i].position.z);
            elements[i].obj.transform.localScale = new Vector3((elements[i].scale.x) * (1 - zoom), elements[i].scale.y * (1 - zoom), elements[i].scale.z);
        }
    }
}
