﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Start()
	{
		temp ();
	}
	// Use this for initialization
	void OnGUI () {

		if(GUI.Button(new Rect(115,310,120,30), "Main Menu")) {
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(115,350,120,30), "Exit")) {
			Application.Quit();
		}
	}
	void temp()
	{
		GetComponent<AudioSource>().loop = true; 
		GetComponent<AudioSource>().Play();
	}

}
