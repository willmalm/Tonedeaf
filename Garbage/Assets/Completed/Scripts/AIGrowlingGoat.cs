using UnityEngine;
using System.Collections;

public class AIGrowlingGoat : MonoBehaviour
{
    private PlayerVariables playerVar;
	void Start ()
    {
        playerVar = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
	}
	void Update ()
    {
	    
	}
    private void Knockdown()
    {
        playerVar.knockdown = true;
    }
}
