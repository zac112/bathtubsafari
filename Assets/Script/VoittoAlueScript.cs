using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoittoAlueScript : MonoBehaviour {

	public Text VoittoTeksti;
    
	void Start () {
		VoittoTeksti.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		GameObject go = GameObject.Find("GameManager");
        if(go != null) go.GetComponent<GameManager>().LisaaPiste();
		VoittoTeksti.gameObject.SetActive (true);
	}
}
