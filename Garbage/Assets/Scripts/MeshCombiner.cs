using UnityEngine;
using System.Collections;

public class MeshCombiner : MonoBehaviour {
	void LateUpdate () { //Fuck visual kukstudio
        Material mat = gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        MeshFilter[] filters = gameObject.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] c = new CombineInstance[filters.Length];
        Vector3 position = transform.position, rotation = transform.eulerAngles, scale = transform.localScale;  //Helvete unity fixa detta
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        transform.localScale = Vector3.one;

        for(int i = 0; i < filters.Length; i++){
            c[i].mesh = filters[i].sharedMesh;
            c[i].transform = filters[i].transform.localToWorldMatrix;
            
        }

        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        
        filter.mesh = new Mesh();
        filter.mesh.CombineMeshes(c);

        MeshRenderer rend = gameObject.AddComponent<MeshRenderer>();
        rend.sharedMaterial = mat;

        Transform[] hora = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform slampa in hora){ //Fittprogram gå och dö
            if(slampa != null){
                if (slampa.gameObject != gameObject) DestroyImmediate(slampa.gameObject); //Försvinn
            }
        }

        transform.position = position;  //Horor
        transform.eulerAngles = rotation;
        transform.localScale = scale;


        DestroyImmediate(this);
	}
}
