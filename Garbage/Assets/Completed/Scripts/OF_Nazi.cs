using UnityEngine;
using System.Collections;

public class OF_Nazi : MonoBehaviour {
    public float delay;
    public float delay2;
    public float speed;
    public GameObject dialog;
    public GameObject dialog2;
    private float trueSpeed;
    float timer;
    ObjectVariables var;
    Inventory inv;
    public GameObject Nazi2;
    public Nazi_Controller controller;
    public Nazi_Controller controller2;
    public SpriteSize sprite;
    public SpriteSize sprite2;
    private bool knockback;
    public bool hasItem;
	// Use this for initialization
	void Start () {
        inv = GameObject.FindGameObjectWithTag("GLOBAL_inventory").GetComponent<Inventory>();
        var = GetComponent<ObjectVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        //hasItem = inv.ItemExists(3);
        if (var.used)
        {
            if (hasItem)
            {
                if (!knockback)
                {
                    controller.knockBack = true;
                    knockback = true;
                }
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    trueSpeed += speed / 3 * Time.deltaTime;
                    sprite.direction = -1;
                    sprite2.direction = -1;
                    controller.running = true;
                    controller2.running = true;
                    transform.position += new Vector3(trueSpeed * Time.deltaTime, 0, 0);
                    Nazi2.transform.position += new Vector3(trueSpeed * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                if (timer == 0)
                {
                    controller.knockBack = true;
                }
                timer += Time.deltaTime;
                if (timer >= delay2)
                {
                    dialog.SetActive(true);
                    if (timer >= delay2 + 2)
                    {
                        dialog.SetActive(false);
                        dialog2.SetActive(true);
                        if (timer >= delay2 + 4)
                        {
                            dialog2.SetActive(false);
                            var.used = false;
                            var.force = 0;
                            timer = 0;
                        }
                    }
                }

            }
        }
	}
}
