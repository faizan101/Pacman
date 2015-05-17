using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;
	public GameObject target;
	int Range=3;
	Vector2 wayPointPos;
	static bool canmove=true;
	public GameObject[] enemies;
	GhostMovement temp;
	
	public float speed = 0.2f;
	// Use this for initialization

	void Start () {
		target = GameObject.Find("wayPoint");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canmove) {
			// Waypoint not reached yet? then move closer
			if (transform.position != waypoints [cur].position) {
				Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			}
			// Waypoint reached, select next one
			else
				cur = (cur + 1) % waypoints.Length;
			
			// Animation
			Vector2 dir = waypoints [cur].position - transform.position;
			GetComponent<Animator> ().SetFloat ("DirX", dir.x);
			GetComponent<Animator> ().SetFloat ("DirY", dir.y);

			if (Vector2.Distance (target.transform.position, transform.position) < Range) {
				wayPointPos = target.transform.position;
				transform.position = Vector2.MoveTowards (transform.position, wayPointPos, speed);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			//Destroy (co.gameObject);
			StartCoroutine(MyMethod());
			temp = enemies[0].GetComponent<GhostMovement>();
			temp.cur=0;
			temp = enemies[1].GetComponent<GhostMovement>();
			temp.cur=0;
			temp = enemies[2].GetComponent<GhostMovement>();
			temp.cur=0;
			temp = enemies[3].GetComponent<GhostMovement>();
			temp.cur=0;
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
		//wayPoint
		a.x = 15f; a.y = -30f;
		enemies [5].transform.position = a;

		//cur = 0;
		
	}
	
	IEnumerator MyMethod() {
		canmove = false;
		Restart();
		yield return new WaitForSeconds(4);
		canmove = true;
	}

}
