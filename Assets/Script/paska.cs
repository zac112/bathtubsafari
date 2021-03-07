 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class paska : MonoBehaviour
 {
     private bool mouseDownOnObject;
     private Vector3 sijainti;
	void Update()
	{
		if(!mouseDownOnObject) return;

		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
		pos.y = transform.position.y;
		pos.z = 0;

		transform.position = pos;
	}

    
	private void OnMouseDown()
	{
        sijainti=transform.position;
		mouseDownOnObject = true;
	}

	private void OnMouseUp()
	{
		mouseDownOnObject = false;
	}
    void OnCollisionEnter2D(Collision2D col){
         mouseDownOnObject=false;
     }

     void OnTriggerEnter2D(Collider2D col){
         transform.position=sijainti;
         Debug.Log("osuttiiin rajaan");
         mouseDownOnObject=false;
     }
} 
     
 