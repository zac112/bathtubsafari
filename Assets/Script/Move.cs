﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   public float speed = 3.0f;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.y += speed * Time.deltaTime;
             spriteRenderer.sprite = spriteUp;
         }
         if (Input.GetKey ("s")) {
             pos.y -= speed * Time.deltaTime;
             spriteRenderer.sprite = spriteDown;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
             spriteRenderer.sprite = spriteLeft;
             spriteRenderer.flipX = true;
         }
         if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
             spriteRenderer.sprite = spriteLeft;
             spriteRenderer.flipX = false;
        }
             
 
         transform.position = pos;
     
        
    }

    void OnMouseDown(){
        gameObject.transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
    }
}