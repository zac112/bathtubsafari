 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class paska2 : MonoBehaviour
 {
     private float startPosX;
     private float startPosY;
     private bool mouseDownOnObject;
     private Vector3 sijainti;
	void Update()
	{
		if(mouseDownOnObject==true){
                  Vector3 mousePos;
            mousePos=Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition= new Vector3(mousePos.x-startPosX, mousePos.y-startPosY,0);
        }
	}

    
	private void OnMouseDown()
	{
        sijainti=transform.position;
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos;
            mousePos=Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x-this.transform.localPosition.x;
            startPosY = mousePos.y-this.transform.localPosition.y;

            mouseDownOnObject=true;
        }
	}

	private void OnMouseUp()
	{
		mouseDownOnObject = false;
	}
    void OnCollisionEnter2D(Collision2D col){
        
         mouseDownOnObject=false;
     }

     void OnTriggerEnter2D(Collider2D col){
        mouseDownOnObject=false;
         transform.position=sijainti;
         Debug.Log("osuttiiin rajaan");
         
     }
} 
     
 