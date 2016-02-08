using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pauseWindow;
    public GameObject savePrompt;
    public bool pauseBool = true;
    public int invSpeed;
    public int invEnabledPos;
    public int invDisabledPos;
    GameObject inventory;
    GameObject map;
    GameObject player;
    SpriteRenderer invSprite;
    bool invEnabled;
    Vector3 invCurrent;
    public float invInvisible;
    public float invVisible;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        player = GameObject.FindGameObjectWithTag("Player");
        //map = GameObject.FindGameObjectWithTag("Map");
        invSprite = inventory.GetComponent<SpriteRenderer>();
    }
	void Update () {
        invInvisible = player.transform.position.x + invDisabledPos;
        invVisible = player.transform.position.x + invEnabledPos;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseWindow.SetActive(pauseBool);
            pauseBool = !pauseBool;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            invCurrent = inventory.transform.position;
            invEnabled = !invEnabled;
            //invSprite.enabled = inv;
           /* foreach (Transform child in inventory.transform)
            {
                //child.gameObject.SetActive(inv);
            }*/
        }
        if (invEnabled)
        {
            if (inventory.transform.position.x < invVisible)
            {
                inventory.transform.position += new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                inventory.transform.position = new Vector3(invVisible, inventory.transform.position.y, 0);
            }
        }
        else if (invEnabled == false)
        {

            if (inventory.transform.position.x > invInvisible)
            {
                inventory.transform.position -= new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                inventory.transform.position = new Vector3(invInvisible, inventory.transform.position.y, 0);
            }
        }
	}
}
