using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour {
	[SerializeField]
	EnemyData data;
	[SerializeField]
	Text label;

	Enemy enemy;
	
	void Start() {
		enemy = this.GetComponent<Enemy>();
	}

	public void Update () {
		Update_Label();
		Update_Sprite();
	}

	void Update_Label() {
		label.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
		label.text = data.name;
	}

	void Update_Sprite() {
		if (enemy == null) {
			enemy = this.GetComponent<Enemy>();
		}

		enemy.Change_Color(data.color);
		enemy.speed = data.speed;
		enemy.distance = data.distance;
	}
}
