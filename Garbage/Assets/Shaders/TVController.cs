using UnityEngine;
using System.Collections;

public class TVController : MonoBehaviour {
    public GameObject screen;
    [Range(0,1)]
    public float value;
    public MeshRenderer mesh;
    Material mat;
	// Use this for initialization
	void Start () {
        mesh = screen.GetComponent<MeshRenderer>();
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
	}
}
