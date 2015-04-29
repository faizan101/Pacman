using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {
	//var count=0.0;
	//var ScoreText = "Points: 0";
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name == "pacman") 
		{
			//Debug.Log ("here!");
			count++;
			//Debug.Log (count);
			//ScoreText = "Points: " + count;
			Destroy (gameObject);
		}

	}
}

