using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace SharedData
{
	[CreateAssetMenu]
	public class Converter : ScriptableObject
	{
		public ItemDatas ItemData;

		public void ConvertToJson()
		{
			string path = Path.Combine(Application.dataPath, "ItemData.json");

			string s = JsonConvert.SerializeObject(ItemData, Formatting.Indented);
			File.WriteAllText(path, s, Encoding.UTF8);
		}
	}


	[CustomEditor(typeof(Converter))]
	public class ConverterEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			var script = (Converter)target;

			if (GUILayout.Button("ConvertItemData", GUILayout.Height(30)))
			{
				script.ConvertToJson();
			}
		}
	}
}