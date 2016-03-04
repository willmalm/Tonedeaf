using UnityEngine;
using System.Collections;

public class TVController : MonoBehaviour {
    [Range(0,1)]
    public float value;
    public MeshRenderer mesh;
    Material mat;
	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        {
            mat = mesh.material;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (mat != null) {
            mat.SetFloat("_Noise", value);
        }
        if (Input.GetKey(KeyCode.F))
        {
            value = 1;
        }
        else
        {
            value = 0;
        }
	}
}
