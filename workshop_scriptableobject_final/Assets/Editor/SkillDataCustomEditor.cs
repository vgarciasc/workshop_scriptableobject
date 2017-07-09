using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [CustomEditor(typeof(SkillData))]
public class SkillDataCustomEditor : Editor {
	
	public override void OnInspectorGUI() {
		SkillData data = (SkillData) target;

		EditorGUILayout.LabelField("Skill Name", EditorStyles.boldLabel);
		data.name = GUILayout.TextField(data.name);

		EditorGUILayout.Space();

		for (int i = 0; i < data.effects.Count; i++) {
			Effect effect = data.effects[i];

			GUILayout.BeginVertical("Box");
			GUILayout.BeginHorizontal("Box", EditorStyles.miniButton);	
			effect.type = (EffectType) EditorGUILayout.EnumPopup(effect.type);

			effect.duration = EditorGUILayout.Slider(effect.duration,
				0f,
				3f);

			if (GUILayout.Button("X", EditorStyles.miniButtonRight)) {
				data.effects.RemoveAt(i);
				Undo.RecordObject(data, "Remove Effect");
			}

			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}

		if (GUILayout.Button("Add", EditorStyles.miniButtonRight)) {
			data.effects.Add(new Effect());
			Undo.RecordObject(data, "Add Effect");
		}
	}
}
