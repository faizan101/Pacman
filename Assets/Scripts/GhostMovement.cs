using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GhostMovement : MonoBehaviour {

	public Transform[] waypoints;
	public int cur = 0;
	public bool canmove=true;
	
	public float speed = 0.2f;
	// Use this for initialization

	void Start () {

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
			}
		}
}
