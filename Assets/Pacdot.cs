using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {
	public static int count=0;
	//temp obj = new temp ();
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.name == "pacman") 
		{

			count++;
			Debug.Log(count);
			Destroy (gameObject);

		}

	}
}

