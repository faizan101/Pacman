using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pacdot1 : MonoBehaviour {
	public static float score;
	void Start()
	{
		score=0.0f;
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.name == "pacman") 
		{
			if(score==193f){
				//Debug.LogError("max Score reached");
				Application.LoadLevel("MainMenu");}
			score++;
			//Debug.Log(score);
			Destroy (gameObject);
			
			//AddScore(score);
			
		}
		
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (160, 80, 120, 50), "Score:");
		GUI.Label (new Rect (210, 80, 120, 50), score.ToString ());
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

