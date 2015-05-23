using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void OnGUI () {
		
		if(GUI.Button(new Rect(600,170,120,30), "Restart Level")) {
			Application.LoadLevel("Pacman1");
		}
		if(GUI.Button(new Rect(600,210,120,30), "MainMenu")) {
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(600,250,120,30), "Exit")) {
			Application.Quit();
		}
	}
}
