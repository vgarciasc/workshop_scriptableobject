using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Rigidbody2D rb;
	SpriteRenderer sr;
	[SerializeField]
	Text label;

	public float speed = 0.5f;
	public float distance = 3f;

	void Start() {
		init();
		StartCoroutine(Random_Actions());
	}

	void Update() {
		label.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
	}

	void init() {
		rb = this.GetComponent<Rigidbody2D>();
		sr = this.GetComponent<SpriteRenderer>();
	}

	IEnumerator Random_Actions() {
		while (true) {
			//calcula novo ponto para o qual ele vai se deslocar
			float x = Random.Range(-distance, distance);
			float y = Random.Range(-distance, distance);

			//inicia movimentacao, e espera movimentacao terminar
			yield return Move(new Vector3(x, y));
		}
	}

	IEnumerator Move(Vector3 position) {
		Debug.Log("Now at: " + this.transform.position +
			"\nGoing to: " + position);

		//atribui velocidade na direção do ponto definido
		rb.velocity = (position * speed);
		//se for para a direçao oposta, flippa o sprite
		sr.flipX = position.x > this.transform.position.x;
		StartCoroutine(Stop_Moving(position));

		//espera ate acabar o tempo de deslocamento, ou ate ter chegado
		yield return new WaitUntil(() => Arrived_Yet(position)
			|| should_stop_moving);

		rb.velocity = Vector2.zero;
	}

	//corotina para cancelar o movimento se estiver demorando demais
	//por exemplo, caso esteja empacado numa parede (nunca chega no ponto)
	bool should_stop_moving = false;
	IEnumerator Stop_Moving(Vector3 position) {
		should_stop_moving = false;

		yield return new WaitForSeconds(1.0f);
		
		should_stop_moving = true;
	}

	//calcula se ja chegou no ponto (nao precisa ter chegado exatamente)
	bool Arrived_Yet(Vector3 position) {
		float x = this.transform.position.x - position.x;
		float y = this.transform.position.y - position.y;
		float threshold = 0.15f;

		if (Mathf.Abs(x) < threshold &&
			Mathf.Abs(y) < threshold) {
			return true;
		}

		return false;
	}

	public void Change_Color(Color color) {
		if (sr == null) {
			init();
		}
		sr.color = color;
	}
}
