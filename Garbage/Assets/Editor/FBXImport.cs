using UnityEngine;
using System.Collections;
using UnityEditor;

//Just place this script in the Editor folder.
public class FBXImport : AssetPostprocessor {	
	void OnPreprocessModel(){
		if(assetPath.EndsWith("fbx/") || assetPath.EndsWith("fbx")){
			(assetImporter as ModelImporter).globalScale = 100;
		}
		else (assetImporter as ModelImporter).globalScale = 1;
	}
}
