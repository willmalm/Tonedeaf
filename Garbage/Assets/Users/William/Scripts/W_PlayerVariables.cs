using UnityEngine;
using System.Collections;

public class W_PlayerVariables : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int speed;
    public bool immune;
    public bool knockdown;
    public bool immobile;

    [Range(0,4)]
    public int gridLayer;
}
