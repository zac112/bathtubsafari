using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{  public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.y += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.y -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         }
             
 
         transform.position = pos;
     
        
    }

    void OnMouseDown(){
        gameObject.transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
    }
}
