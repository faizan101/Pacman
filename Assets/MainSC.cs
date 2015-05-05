using UnityEngine;
using System.Collections;

public class MainSC : MonoBehaviour {
	public string FirstLevel1;
	// Use this for initialization
	void OnGUI () {
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(140,210,120,30), "Start")) {
			Application.LoadLevel(FirstLevel1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(140,250,120,30), "Exit")) {
			Application.Quit();
		}
	}
}
