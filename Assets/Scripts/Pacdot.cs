using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour {
	public static float score;
	void Start()
	{
		score=0.0f;
	}
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name == "pacman") 
		{
			if(score==327f){
				Debug.LogError("max Score reached");
				Application.LoadLevel("Level1");}
			score++;
			//Debug.Log(score);
			Destroy (gameObject);

			//AddScore(score);

		}

	}

	void OnGUI()
	{
		GUI.Label (new Rect (160, 12, 120, 80), "Score:");
		GUI.Label (new Rect (210, 12, 120, 80), score.ToString ());
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

