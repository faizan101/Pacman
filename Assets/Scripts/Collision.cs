using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision : MonoBehaviour {

	static int Lives;
	//static bool canmove=true;
	public GameObject[] enemies;
	public GameObject[] Life;
	EnemyAI temp;
	GhostMovement temp1;
	// Use this for initialization
	void Start () {
		Lives=3;
	}

	void OnGUI()
	{

	}
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			//Destroy (co.gameObject);
			if(Lives==3)
			{
				Lives--;
				Destroy(Life[0]);
			}
			else if(Lives==2)
			{
				Lives--;
				Destroy(Life[1]);
			}
			else
			{
				Lives--;
				Destroy(Life[2]);
			}
			if(Lives==0)
			{
				Application.LoadLevel("GameOver");
			}
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
		a.x = 15f; a.y = -15f;
		enemies [2].transform.position = a;
		//inky
		a.x = 12.5f; a.y = -15f;
		enemies [3].transform.position = a;
		//pacman
		a.x = 15f; a.y = -30f;
		enemies [4].transform.position = a;

		
		//cur = 0;
		
	}
	
	IEnumerator MyMethod() {
		Debug.Log ("Here");
		temp = enemies[0].GetComponent<EnemyAI>();
		temp.canmove1=false;
		temp = enemies[1].GetComponent<EnemyAI>();
		temp.canmove1=false;
		temp1 = enemies[2].GetComponent<GhostMovement>();
		temp1.canmove=false;
		temp1 = enemies[3].GetComponent<GhostMovement>();
		temp1.canmove=false;
		Restart();

		yield return new WaitForSeconds(0.5f);
		Restart ();
		yield return new WaitForSeconds(3.5f);
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
		//temp = enemies[3].GetComponent<EnemyAI>();
		//temp.canmove1=true;
	}
}
