using UnityEngine;
using System.Collections;

public class MainSC : MonoBehaviour {
	public string FirstLevel1;
	// Use this for initialization
	void OnGUI () {

		if(GUI.Button(new Rect(200,210,120,30), "Start")) {
			Application.LoadLevel(FirstLevel1);
		}
		if(GUI.Button(new Rect(200,250,120,30), "Exit")) {
			Application.Quit();
		}
	}
}
