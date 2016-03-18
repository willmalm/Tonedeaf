using UnityEngine;
using System.Collections;

public class SpriteTransision : MonoBehaviour {
public Texture2D tex;
	AudioSource aSrc;
Material m;
ObjectVariables oV;
bool playSound = true;

	// Use this for initialization
	void Start () {
		MeshRenderer r = gameObject.GetComponent<MeshRenderer>();
		if(r != null)
		{
			m = r.material;
		}
		
		oV = gameObject.GetComponent<ObjectVariables>();
		aSrc = GetComponent<AudioSource> ();
	}

	
	// Update is called once per frame
	void Update () {
	if (m != null && oV != null)
	{
		float lerp = oV.force/oV.toughness;
		
		
		if(oV.used){
			if(playSound){
				playSound = false;
				
				//SPELA LJUD KOD
					aSrc.Play();
				
				
				//Byt texture
				m.SetTexture("_MainTex",tex);
				m.SetTexture("_SecondTex",tex);
				m.SetFloat("_Lerp", 0);
				m.color = Color.white;
			}
			
			
		}
		else{
			m.SetFloat("_Lerp", lerp);
			oV.force -= Time.deltaTime*0.1f;
			if(oV.force < 0) oV.force = 0;
		}
		
	}
	}
}
