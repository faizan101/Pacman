using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision1 : MonoBehaviour {

	static int Lives;
	//static bool canmove=true;
	public GameObject[] enemies;
	public GameObject[] Life;
	public GameObject DeathGo;
	EnemyAI1 temp;
	GhostMovement1 temp1;
	// Use this for initialization
	void Start () {
		Lives=3;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D co) {
		Vector2 a=transform.position;
		if (co.name == "pacman") {
			//Destroy (co.gameObject);
			if(Lives==3)
			{
				Lives--;
				Destroy(Life[0]);
				PlayDeath();
			}
			else if(Lives==2)
			{
				Lives--;
				Destroy(Life[1]);
				PlayDeath();
			}
			else
			{
				Lives--;
				Destroy(Life[2]);
				PlayDeath();
			}
			if(Lives==0)
			{
				StartCoroutine(Level());
			}
			StartCoroutine(MyMethod());
			temp = enemies[0].GetComponent<EnemyAI1>();
			temp.cur=0;
			temp = enemies[1].GetComponent<EnemyAI1>();
			temp.cur=0;
			temp1 = enemies[2].GetComponent<GhostMovement1>();
			temp1.cur=0;
			temp1 = enemies[3].GetComponent<GhostMovement1>();
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
		a.x = 25.5f; a.y = -12.4f;
		enemies [0].transform.position = a;
		//pinky
		a.x = 27.84f; a.y = -15.01f;
		enemies [1].transform.position = a;
		//clyde
		a.x = 25.47f; a.y = -15f;
		enemies [2].transform.position = a;
		//inky
		a.x = 23f; a.y = -15f;
		enemies [3].transform.position = a;
		//pacman
		a.x = 200f; a.y = -100f;
		enemies [4].transform.position = a;

		
		//cur = 0;
		
	}
	
	IEnumerator MyMethod() {
		Debug.Log ("Here");
		temp = enemies[0].GetComponent<EnemyAI1>();
		temp.canmove1=false;
		temp = enemies[1].GetComponent<EnemyAI1>();
		temp.canmove1=false;
		temp1 = enemies[2].GetComponent<GhostMovement1>();
		temp1.canmove=false;
		temp1 = enemies[3].GetComponent<GhostMovement1>();
		temp1.canmove=false;
		Restart();

		yield return new WaitForSeconds(0.5f);
		Restart ();
		yield return new WaitForSeconds(3.5f);
		Vector2 a=transform.position;
		a.x = 6.37f; a.y = -28.7f;
		enemies [4].transform.position = a;

		temp = enemies[0].GetComponent<EnemyAI1>();
		temp.canmove1=true;
		temp.canmove = true;
		temp = enemies[1].GetComponent<EnemyAI1>();
		temp.canmove1=true;
		temp.canmove = true;
		/////////////////////////////////////////////////
		temp1 = enemies[2].GetComponent<GhostMovement1>();
		temp1.canmove=true;
		temp1 = enemies[3].GetComponent<GhostMovement1>();
		temp1.canmove=true;
		//temp = enemies[3].GetComponent<EnemyAI>();
		//temp.canmove1=true;
	}

	void PlayDeath()
	{
		GameObject Death = (GameObject)Instantiate (DeathGo);
		Death.transform.position = enemies [4].transform.position;
		GetComponent<AudioSource> ().Play ();
	}

	IEnumerator Level()
	{
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("GameOver");

	}
}
