using UnityEngine;
using System.Collections;
using UnityEditor;

public class UnlitMultitextureInspector : ShaderGUI {
	private bool Float2bool(float f){
		if(f == 0) return false;
		else return true;
	}

	private float Bool2Float(bool b){
		if(b) return 1;
		else return 0;
	}


	public override void OnGUI (MaterialEditor materialEditor, MaterialProperty[] properties){
		//base.OnGUI(materialEditor, properties);
		Material targetMat = materialEditor.target as Material;
		//GUILayout.Space(50);	//Debug space, remove later


		Rect r = GUILayoutUtility.GetRect(0,0);
		r.height = 16;

		Rect rect = new Rect(r.position, r.size);
		GUILayout.Space(250);

		GUI.Label(rect,"Selection Mask", EditorStyles.boldLabel); rect.y += rect.height;
		rect.height = 50;	rect.width = rect.height;
		targetMat.SetTexture("_Masks",(Texture)EditorGUI.ObjectField(rect,targetMat.GetTexture("_Masks"),	typeof(Texture),false));	rect.x += rect.width;	rect.width = r.width - rect.width;	rect.height/=3;	rect.width/=2;
		targetMat.SetFloat("_UseSecond",Bool2Float(		GUI.Toggle(rect,Float2bool(targetMat.GetFloat("_UseSecond")),	"Use r", "Button")));	rect.y += rect.height;
		targetMat.SetFloat("_UseFourth",Bool2Float(		GUI.Toggle(rect,Float2bool(targetMat.GetFloat("_UseFourth")),	"Use b", "Button")));	rect.x += rect.width;	rect.y -= rect.height;
		targetMat.SetFloat("_UseThird",Bool2Float(		GUI.Toggle(rect,Float2bool(targetMat.GetFloat("_UseThird")),	"Use g", "Button")));	rect.y += rect.height;
		targetMat.SetFloat("_UseFifth",Bool2Float(		GUI.Toggle(rect,Float2bool(targetMat.GetFloat("_UseFifth")),	"Use a", "Button")));	rect.y += rect.height;	rect.x -= rect.width;	rect.width*=2;
		targetMat.SetFloat("_BlendType",Bool2Float(		GUI.Toggle(rect,Float2bool(targetMat.GetFloat("_BlendType")),	"Replace Masked", "Button")));
		rect.x = r.x;	rect.width = r.width;	rect.y += rect.height + 15;	rect.height = 16;



		GUI.Label(rect,"Color Override", EditorStyles.boldLabel);	rect.y += rect.height;	rect.width = 120;
		targetMat.SetFloat("_OverrideType",GUI.Toolbar(rect,(int)targetMat.GetFloat("_OverrideType"),new string[]{"Additive", "Multiply"}));	rect.x += rect.width;	rect.width = r.width - rect.width;
		targetMat.SetColor("_Color", EditorGUI.ColorField(rect,targetMat.GetColor("_Color")));rect.x = r.x;	rect.width = r.width;	rect.y += rect.height;
		GUI.Label(rect,"Strength");rect.x += 60; rect.width-= 60;
		targetMat.SetFloat("_LightStrength",EditorGUI.Slider(rect,targetMat.GetFloat("_LightStrength"),0,1));
		rect.x = r.x;	rect.width = r.width;	rect.y += rect.height + 15;


		rect.height = 50;	rect.width = rect.height;
		targetMat.SetTexture("_MainTex",	(Texture)EditorGUI.ObjectField(rect,targetMat.mainTexture,typeof(Texture),false));					rect.x += r.width/5;
		targetMat.SetTexture("_SecondTex",	(Texture)EditorGUI.ObjectField(rect,targetMat.GetTexture("_SecondTex"),	typeof(Texture),false));	rect.x += r.width/5;
		targetMat.SetTexture("_ThirdTex",	(Texture)EditorGUI.ObjectField(rect,targetMat.GetTexture("_ThirdTex"),	typeof(Texture),false));	rect.x += r.width/5;
		targetMat.SetTexture("_FourthTex",	(Texture)EditorGUI.ObjectField(rect,targetMat.GetTexture("_FourthTex"),	typeof(Texture),false));	rect.x += r.width/5;
		targetMat.SetTexture("_FifthTex",	(Texture)EditorGUI.ObjectField(rect,targetMat.GetTexture("_FifthTex"),	typeof(Texture),false));	rect.y += rect.height + 5;	rect.height = 16;	rect.width = r.width;	rect.x = r.x;






		//GUI.Label(rect,"Main color");	rect.x += 100;	rect.width -= 100;	rect.width /= 3;
		rect.x = r.x;	rect.width /= 5;	rect.height = 16;
		Rect startRect = new Rect(rect.position, rect.size);


		targetMat.SetColor("_M1r", EditorGUI.ColorField(rect,targetMat.GetColor("_M1r")));		rect.y += rect.height;
		targetMat.SetColor("_M1g", EditorGUI.ColorField(rect,targetMat.GetColor("_M1g")));		rect.y += rect.height;
		targetMat.SetColor("_M1b", EditorGUI.ColorField(rect,targetMat.GetColor("_M1b")));		startRect.x += rect.width;	rect = startRect;


		//GUI.Label(rect,"Mask.r color");	rect.x += 100;	rect.width -= 100;	rect.width /= 3;
		targetMat.SetColor("_M2r", EditorGUI.ColorField(rect,targetMat.GetColor("_M2r")));		rect.y += rect.height;
		targetMat.SetColor("_M2g", EditorGUI.ColorField(rect,targetMat.GetColor("_M2g")));		rect.y += rect.height;
		targetMat.SetColor("_M2b", EditorGUI.ColorField(rect,targetMat.GetColor("_M2b")));		startRect.x += rect.width;	rect = startRect;


		//GUI.Label(rect,"Mask.g color");	rect.x += 100;	rect.width -= 100;	rect.width /= 3;
		targetMat.SetColor("_M3r", EditorGUI.ColorField(rect,targetMat.GetColor("_M3r")));		rect.y += rect.height;
		targetMat.SetColor("_M3g", EditorGUI.ColorField(rect,targetMat.GetColor("_M3g")));		rect.y += rect.height;
		targetMat.SetColor("_M3b", EditorGUI.ColorField(rect,targetMat.GetColor("_M3b")));		startRect.x += rect.width;	rect = startRect;


		//GUI.Label(rect,"Mask.b color");	rect.x += 100;	rect.width -= 100;	rect.width /= 3;
		targetMat.SetColor("_M4r", EditorGUI.ColorField(rect,targetMat.GetColor("_M4r")));		rect.y += rect.height;
		targetMat.SetColor("_M4g", EditorGUI.ColorField(rect,targetMat.GetColor("_M4g")));		rect.y += rect.height;
		targetMat.SetColor("_M4b", EditorGUI.ColorField(rect,targetMat.GetColor("_M4b")));		startRect.x += rect.width;	rect = startRect;


		//GUI.Label(rect,"Mask.a color");	rect.x += 100;	rect.width -= 100;	rect.width /= 3;
		targetMat.SetColor("_M5r", EditorGUI.ColorField(rect,targetMat.GetColor("_M5r")));		rect.y += rect.height;
		targetMat.SetColor("_M5g", EditorGUI.ColorField(rect,targetMat.GetColor("_M5g")));		rect.y += rect.height;
		targetMat.SetColor("_M5b", EditorGUI.ColorField(rect,targetMat.GetColor("_M5b")));		startRect.x += rect.width;	rect = startRect;


		startRect.x = r.x + startRect.width;	startRect.height = startRect.height*3;
		Texture[] tex 	= new Texture[]{targetMat.GetTexture("_SecondTex"),targetMat.GetTexture("_ThirdTex"),targetMat.GetTexture("_FourthTex"),targetMat.GetTexture("_FifthTex")};
		bool[] 	texB 	= new bool[]{Float2bool(targetMat.GetFloat("_UseSecond")),Float2bool(targetMat.GetFloat("_UseThird")),Float2bool(targetMat.GetFloat("_UseFourth")),Float2bool(targetMat.GetFloat("_UseFifth"))};
		for(int i = 0; i < 4; i++){
			if(tex[i]==null || !texB[i])EditorGUI.DrawRect(startRect,new Color(0,0,0,0.5f));
			startRect.x += startRect.width;
		}

		EditorUtility.SetDirty (targetMat);
		//targetMat.GetColor("_Color");
	}
}
