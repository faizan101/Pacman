using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour {
	public static float score=0.0f;

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name == "pacman") 
		{
			score++;
			Debug.Log(score);
			Destroy (gameObject);
			//AddScore(score);

		}

	}

	void OnGUI()
	{
		GUI.Label (new Rect (260, 12, 120, 50), "Score:");
		GUI.Label (new Rect (310, 12, 120, 50), score.ToString ());
	}
	/*void AddScore(int newScore)
	{
		score += newScore;
		UpdateScore ();
	}
	void UpdateScore()
	{

		scoreText.text = "Score: " + score;
	}*/
}

