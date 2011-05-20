using UnityEngine;
using System.Collections.Generic;

public class MaterialExportData
{
	private Material m;
	private List<string> textures;

	public MaterialExportData (Transform t, List<string> textures)
	{
		m = t.gameObject.renderer.sharedMaterial;
		this.textures = textures;
	}

	public string Name {
		get { return NamesUtil.CleanMat (m.name); }
	}
	
	public string Type {
		get { return MaterialMapper.GetJ3DRenderer (m); }
	}
	
	public Color Color {
		get { return m.color; }
	}
	
	public string[] Textures {
		get {
			List<string> tjs = new List<string> ();
			
			foreach (string tn in textures) {
				tjs.Add (
					"\"" + MaterialMapper.GetJ3DTextureName (tn) + "\": " + 
					"\"" + NamesUtil.CleanLc (m.GetTexture ("_MainTex").name) + "\""
				);
			}
			
			return tjs.ToArray ();
		}
	}
	
	public string SpecularIntensity {
		get {
			return (m.HasProperty("_Shininess")) ? (m.GetFloat ("_Shininess")*128).ToString (ExporterProps.LN) : "0";
		}
	}
}


