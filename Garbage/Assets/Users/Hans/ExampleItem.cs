using UnityEngine;
using System.Collections;

public class ExampleItem : Item
{
    // Use this for initialization
    public GameObject[] items;
    public override void Start()
    {
        //base.Start();
    }

    // Update is called once per frame
    private void Update()
    { }
    public override void Effect()
    {
        transform.position = new Vector3(1, 1, 0);
    }
}
