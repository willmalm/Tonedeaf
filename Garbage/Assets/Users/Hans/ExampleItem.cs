using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExampleItem : Item
{
    // Use this for initialization
    RectTransform rt;
    public GameObject[] items;
    public void Start()
    {
        rt = GetComponent<RectTransform>();
        //base.Start();
    }

    // Update is called once per frame
    private void Update()
    { }
    public void Effect()
    {
        transform.position = new Vector3(1, 1, 0);
        rt.position = new Vector3(1, 1, 0);
    }
}
