using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    // Use this for initialization
    public virtual void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public virtual void SetInventoryPosition(int xPosition, int yPosition)
    {
        transform.position = new Vector3(-10 + (xPosition), -3 - (yPosition), 0);
    }
    public virtual void Effect()
    {

    }
}
