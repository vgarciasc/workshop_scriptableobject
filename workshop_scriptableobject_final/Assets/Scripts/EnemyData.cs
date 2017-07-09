using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Enemy Data", order = 1)]
public class EnemyData : ScriptableObject {
	[Header("Enemy Appearance")]
	public string name = "DEFAULT";
	public Color color = Color.white;

	[Header("Enemy Movement")]
	[Tooltip("The speed at which the enemy moves.")]
	[Range(0f, 5f)]
	public float speed = 3f;
	[Tooltip("The maximum distance the enemy moves in a certain cycle.")]
	[Range(0f, 5f)]
	public float distance = 3f;
}