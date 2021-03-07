using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoittoAlueScript : MonoBehaviour {

	// Reference to WinText game object
	public Text VoittoTeksti;
    

	// Use this for initialization
	void Start () {
		// Turn "You Win!" sign at the start
		VoittoTeksti.gameObject.SetActive (false);
	}

	// If target car (red one) exits the playground
	void OnTriggerEnter2D (Collider2D col)
	{
		// then "You Win!" sign is turned on
		VoittoTeksti.gameObject.SetActive (true);
	}
}
