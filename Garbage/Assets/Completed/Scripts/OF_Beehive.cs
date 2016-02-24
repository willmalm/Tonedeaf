using UnityEngine;
using System.Collections;

public class OF_Beehive : MonoBehaviour
{
    public GameObject beehive;
    public GameObject bees;
    public GameObject sprite_Beehive;

    private ObjectVariables var_Beehive;
    private ObjectVariables var_Bees;

    private BeehiveController ctrl_Beehive;

	void Start()
    {
        ctrl_Beehive = sprite_Beehive.GetComponent<BeehiveController>();
        var_Beehive = beehive.GetComponent<ObjectVariables>();
        var_Bees = bees.GetComponent<ObjectVariables>();
    }

	void Update ()
    {
        if (var_Beehive.used)
        {
            ctrl_Beehive.dead = true;
            bees.GetComponent<Collider2D>().enabled = false;
        }
        if (var_Bees.used)
        {
            ctrl_Beehive.fuckYou = true;
        }
    }
}
