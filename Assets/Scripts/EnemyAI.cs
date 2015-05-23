using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {
	
	// ****************************EnemyAI*****************************************
	public Transform target;
	public float updateRate = 2f;
	private Seeker seeker;
	private Rigidbody2D rb;
	public Path path;
	public float speed = 300f;
	public ForceMode2D fMode;
	
	[HideInInspector]
	public bool pathIsEnded = false;
	public float nextWaypointDistance = 3;
	private int currentWaypoint = 0;

	//***************************************GhostMove********************************
	public Transform[] waypoints;
	int Range=4;
	public float speed1 = 0.2f;
	public bool canmove=true;
	[HideInInspector]
	public bool canmove1=true;
	[HideInInspector]
	public int cur = 0;
	int Lives=3;
	//EnemyAI temp;
	//public GameObject[] enemies;
	//********************************************************************************
	
	void Start () {
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		
		if (target == null) {
			Debug.LogError ("No Player found? PANIC!");
			return;
		}
		
		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		
		StartCoroutine (UpdatePath ());
	}
	
	IEnumerator UpdatePath () {
		if (target == null) {
			//TODO: Insert a player search here.
			return false;
		}
		
		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		
		yield return new WaitForSeconds ( 1f/updateRate );
		StartCoroutine (UpdatePath());
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("We got a path. Did it have an error? " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	//******************************************************************************************************
	void FixedUpdate () {


		//******************************************************************************************************
		if (canmove && canmove1) {
			// Waypoint not reached yet? then move closer
				//Debug.Log ("Comes here");
			if (transform.position != waypoints [cur].position) {
				Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed1);
				GetComponent<Rigidbody2D> ().MovePosition (p);
			}
			// Waypoint reached, select next one
			else
				cur = (cur + 1) % waypoints.Length;
			
			// Animation
			Vector2 dir = waypoints [cur].position - transform.position;
			GetComponent<Animator> ().SetFloat ("DirX", dir.x);
			GetComponent<Animator> ().SetFloat ("DirY", dir.y);
			if (Vector2.Distance (target.transform.position, transform.position) < Range) 
				canmove=false;
		}
	
		//******************************************************************************************************
		if (!canmove && canmove1) {
			if (target == null) {
				//TODO: Insert a player search here.
				return;
			}
		
			//TODO: Always look at player?
		
			if (path == null)
				return;
		
			if (currentWaypoint >= path.vectorPath.Count) {
				if (pathIsEnded)
					return;
			
				Debug.Log ("End of path reached.");
				pathIsEnded = true;
				return;
			}
			pathIsEnded = false;
		
			//Direction to the next waypoint
			Vector3 dir1 = (path.vectorPath [currentWaypoint] - transform.position).normalized;
			dir1 *= speed * Time.fixedDeltaTime;
		
			//if (Vector2.Distance (target.transform.position, transform.position) < 10f) 
			rb.AddForce (dir1, fMode);

			Vector2 dir = transform.position;
			GetComponent<Animator> ().SetFloat ("DirX", dir.x);
			GetComponent<Animator> ().SetFloat ("DirY", dir.y);
		
			float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
			if (dist < nextWaypointDistance) {
				currentWaypoint++;
				return;
			}
		}
	}

}
