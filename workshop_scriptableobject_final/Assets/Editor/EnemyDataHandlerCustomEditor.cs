using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyDataHandler))]
public class EnemyDataHandlerCustomEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		EnemyDataHandler enemy = (EnemyDataHandler) target;

		if (GUILayout.Button("Preview")) {
			enemy.Update();
		}
	}
}
