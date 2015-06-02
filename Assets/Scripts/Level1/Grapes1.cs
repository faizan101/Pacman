using UnityEngine;
using System.Collections;

public class Grapes1 : MonoBehaviour {
	
	// Use this for initialization
	public GameObject[] enemies;
	EnemyAI1 temp;
	GhostMovement1 temp1;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "pacman") {
			Vector2 a=transform.position;
			a.x=100; a.y=100;
			transform.position=a;
			StartCoroutine(Slow());
		}
	}
	
	IEnumerator Slow()
	{
		//Debug.LogError ("No Grape found? PANIC!");
		temp = enemies[0].GetComponent<EnemyAI1>();
		temp.speed = 50f;
		temp.speed1 = 0.1f;
		temp = enemies[1].GetComponent<EnemyAI1>();
		temp.speed = 50f;
		temp.speed1 = 0.1f;
		temp1 = enemies[2].GetComponent<GhostMovement1>();
		temp1.speed = 0.1f;
		temp1 = enemies[3].GetComponent<GhostMovement1>();
		temp1.speed = 0.1f;
		Debug.Log (temp.speed);
		yield return new WaitForSeconds(7.0f);
		
		temp = enemies[0].GetComponent<EnemyAI1>();
		temp.speed = 100f;
		temp.speed1 = 0.2f;
		temp = enemies[1].GetComponent<EnemyAI1>();
		temp.speed = 100f;
		temp.speed1 = 0.2f;
		temp1 = enemies[2].GetComponent<GhostMovement1>();
		temp1.speed = 0.2f;
		temp1 = enemies[3].GetComponent<GhostMovement1>();
		temp1.speed = 0.2f;
		Destroy (gameObject);
	}
}
