using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour {
	
	public float speed = 0.3f;
	static string x="Temp";
	Vector2 dest = Vector2.zero;

	void Start () {
		dest = transform.position;

	}
	
	void FixedUpdate () {

	
		if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
		{
			dest = (Vector2)transform.position + Vector2.up; x="up";
		}
		if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
		{
			dest = (Vector2)transform.position + Vector2.right; x="right";
		}
		if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
		{
			dest = (Vector2)transform.position - Vector2.up; x="down";
		}
		if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
		{
			dest = (Vector2)transform.position - Vector2.right; x="left";
		}
		
		if (x == "right" ) {
			dest = (Vector2)transform.position + Vector2.right; x="right";
		} else if (x == "left")  {
			dest = (Vector2)transform.position - Vector2.right; x="left";
		} else if (x == "up" ) {
			dest = (Vector2)transform.position + Vector2.up; x="up";
		} else if (x == "down") {
			dest = (Vector2)transform.position - Vector2.up; x="down"; 
		}
		else
			x = "Temp";
		
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);
		
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);

			

		
	}


	bool valid(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == GetComponent<Collider2D>());
	}
}
