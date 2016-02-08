using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pauseWindow;
    public GameObject savePrompt;
    public bool pauseBool = true;
    public int invSpeed;
    GameObject inventory;
    GameObject map;
    SpriteRenderer invSprite;
    bool invEnabled;
    Vector3 invCurrent;
    public Vector3 invDisabled;
    public Vector3 invEnabled;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        map = GameObject.FindGameObjectWithTag("Map");
        invSprite = inventory.GetComponent<SpriteRenderer>();
    }
	void Update () {
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
            inventory.transform.position += new Vector3(invSpeed * Time.deltaTime, 0, 0);
            if (inventory.transform.position.x >= invCurrent.x + 5)
            {
                
            }
            else
            {
                inventory.transform.position += new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
        }
        else if (invEnabled == false)
        {
            
            if (inventory.transform.position.x <= invCurrent.x - 5)
            {
                
            }
            else
            {
                inventory.transform.position -= new Vector3(invSpeed * Time.deltaTime, 0, 0);
            }
        }
	}
}
