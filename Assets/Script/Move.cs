﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int lastDirection;
    private bool up, down, left, right;
    [SerializeField] 
    float speed = 3.0f;
    [SerializeField]
    Sprite spriteUp, spriteDown, spriteLeft;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)){
            up = true;
            left = false;
            right = false;
            down = false;

            spriteRenderer.sprite = spriteUp;
        }
        if(Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)){
            left = true;
            up = false;
            down = false;
            right = false;

            spriteRenderer.sprite = spriteLeft;
            spriteRenderer.flipX = false;
        }
        if(Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)){
            down = true;
            left = false;
            up = false;
            right = false;

            spriteRenderer.sprite = spriteDown;
        }
        if(Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)){
            right = true;
            left = false;
            down = false;
            up = false;

            spriteRenderer.sprite = spriteLeft;
            spriteRenderer.flipX = true;
        }

        if(Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow)){
            up = false;
        }
        if(Input.GetKeyUp("a") || Input.GetKeyUp(KeyCode.LeftArrow)){
            left = false;
        }
        if(Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow)){
            down = false;
        }
        if(Input.GetKeyUp("d") || Input.GetKeyUp(KeyCode.RightArrow)){
            right = false;
        }

        MoveAnkka();
    }

    void MoveAnkka(){
        Vector3 pos = transform.position;
        if(up){
            pos.y += speed * Time.deltaTime;
        } else if (left){
            pos.x -= speed * Time.deltaTime;
        } else if (down){
            pos.y -= speed * Time.deltaTime;
        } else if (right) {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}

