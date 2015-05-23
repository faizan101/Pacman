using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision : MonoBehaviour {

	static int Lives=3;
	//static bool canmove=true;
	public GameObject[] enemies;
	EnemyAI temp;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (360, 12, 120, 50), "Lives:");
		GUI.Label (new Rect (410, 12, 120, 50), Lives.ToString ());
	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			//Destroy (co.gameObject);
			Lives--;
			StartCoroutine(MyMethod());
			temp = enemies[0].GetComponent<EnemyAI>();
			temp.cur=0;
			temp = enemies[1].GetComponent<EnemyAI>();
			temp.cur=0;
			//temp = enemies[2].GetComponent<EnemyAI>();
			//temp.cur=0;
			//temp = enemies[3].GetComponent<EnemyAI>();
			//temp.cur=0;
		}
		//Destroy(target);
		/*if (co.name == "wayPoint") {
			Vector2 a=transform.position;
			a.x=35;
			co.gameObject.transform.position=a;
		}*/
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
		//a.x = 15f; a.y = -15f;
		//enemies [2].transform.position = a;
		//inky
		//a.x = 12.5f; a.y = -15f;
		//enemies [3].transform.position = a;
		//pacman
		//a.x = 15f; a.y = -30f;
		//enemies [4].transform.position = a;

		
		//cur = 0;
		
	}
	
	IEnumerator MyMethod() {
		Debug.Log ("Here");
		temp = enemies[0].GetComponent<EnemyAI>();
		temp.canmove1=false;
		temp = enemies[1].GetComponent<EnemyAI>();
		temp.canmove1=false;
		//temp = enemies[2].GetComponent<EnemyAI>();
		//temp.canmove1=false;
		//temp = enemies[3].GetComponent<EnemyAI>();
		//temp.canmove1=false;
		Restart();

		yield return new WaitForSeconds(0.5f);
		Restart ();
		yield return new WaitForSeconds(4);
		temp = enemies[0].GetComponent<EnemyAI>();
		temp.canmove1=true;
		temp.canmove = true;
		temp = enemies[1].GetComponent<EnemyAI>();
		temp.canmove1=true;
		temp.canmove = true;
		//temp = enemies[1].GetComponent<EnemyAI>();
		//temp.canmove1=true;
		//temp = enemies[2].GetComponent<EnemyAI>();
		//temp.canmove1=true;
		//temp = enemies[3].GetComponent<EnemyAI>();
		//temp.canmove1=true;
	}
}
