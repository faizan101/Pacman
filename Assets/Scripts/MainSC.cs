using UnityEngine;
using System.Collections;

public class MainSC : MonoBehaviour {
	public string FirstLevel1;


	// Use this for initialization
	void Start()
	{
		temp ();
	}

	void OnGUI () {

		if(GUI.Button(new Rect(80,210,120,30), "Start")) {
			Application.LoadLevel(FirstLevel1);
		}
		if(GUI.Button(new Rect(80,250,120,30), "Exit")) {
			Application.Quit();
		}
	}
	void temp()
	{
		GetComponent<AudioSource>().loop = true; 
		GetComponent<AudioSource>().Play();
	}


}
