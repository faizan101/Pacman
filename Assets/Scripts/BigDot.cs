using UnityEngine;
using System.Collections;

public class BigDot : MonoBehaviour {
	public GameObject[] enemies;
	EnemyAI temp;
	GhostMovement temp1;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "pacman") 
		{
			Vector2 a=transform.position;
			a.x=100; a.y=100;
			transform.position=a;
			StartCoroutine(MyMethod());
			temp = enemies[0].GetComponent<EnemyAI>();
			temp.cur=0;
			temp = enemies[1].GetComponent<EnemyAI>();
			temp.cur=0;
			temp1 = enemies[2].GetComponent<GhostMovement>();
			temp1.cur=0;
			temp1 = enemies[3].GetComponent<GhostMovement>();
			temp1.cur=0;
		}
	}
	IEnumerator MyMethod() {
		temp = enemies [0].GetComponent<EnemyAI> ();
		temp.canmove1 = false;
		temp = enemies [1].GetComponent<EnemyAI> ();
		temp.canmove1 = false;
		temp1 = enemies [2].GetComponent<GhostMovement> ();
		temp1.canmove = false;
		temp1 = enemies [3].GetComponent<GhostMovement> ();
		temp1.canmove = false;
		Restart ();
		yield return new WaitForSeconds(0.5f);
		Restart ();
		yield return new WaitForSeconds(8.0f);
		
		temp = enemies[0].GetComponent<EnemyAI>();
		temp.canmove1=true;
		temp.canmove = true;
		temp = enemies[1].GetComponent<EnemyAI>();
		temp.canmove1=true;
		temp.canmove = true;
		/////////////////////////////////////////////////
		temp1 = enemies[2].GetComponent<GhostMovement>();
		temp1.canmove=true;
		temp1 = enemies[3].GetComponent<GhostMovement>();
		temp1.canmove=true;
		Destroy (gameObject);
	}
	void Restart()
	{
		//transform.position = startPos;
		Vector2 a=transform.position;
		//blinky
		a.x = 16.5f; a.y = -15f;
		enemies [0].transform.position = a;
		//pinky
		a.x = 13.5f; a.y = -15f;
		enemies [1].transform.position = a;
		//clyde
		a.x = 15f; a.y = -15f;
		enemies [2].transform.position = a;
		//inky
		a.x = 12.5f; a.y = -15f;
		enemies [3].transform.position = a;
	}
}
