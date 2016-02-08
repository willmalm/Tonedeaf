using UnityEngine;
using System.Collections;

public class W_Obstacle01 : MonoBehaviour {

    bool playerImmune;
    public bool upperCollision;
    public bool lowerCollision;
    Vector2 objPosition;

    void Update()
    {
        objPosition = transform.position;
        RaycastHit2D hitUp = Physics2D.Raycast(objPosition + new Vector2(0, 1), Vector2.down, 1);
        RaycastHit2D hitDown = Physics2D.Raycast(objPosition + new Vector2(0, -1), Vector2.up, 1);

        Debug.DrawLine(transform.position + new Vector3(0, 1, 0), transform.position + new Vector3(0, 2, 0));
        Debug.DrawLine(transform.position + new Vector3(0, -1, 0), transform.position + new Vector3(0, -2, 0));

        
        if(hitUp != false && hitUp.collider != null && hitUp.collider.tag == "Player")
        {
            upperCollision = true;
        }
        else
        {
            upperCollision = false;
        }
        if (hitDown != false && hitDown.collider != null && hitDown.collider.tag == "Player")
        {
            lowerCollision = true;
        }
        else
        {
            lowerCollision = false;
        }
       
    }
}
