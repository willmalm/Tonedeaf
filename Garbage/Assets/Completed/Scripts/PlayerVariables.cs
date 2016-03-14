using UnityEngine;
using System.Collections;

public class PlayerVariables : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float horizontal_speed;
    public float vertical_speed;
    public bool immune;
    public bool knockdown;
    public bool immobile;
    public bool im_screech;
    public bool im_knockdown;
    public bool im_event;
    public Vector3 newPosition;

    void Update()
    {
        if(im_screech || im_knockdown || im_event)
        {
            immobile = true;
        }
        else
        {
            immobile = false;
        }
    }
}
