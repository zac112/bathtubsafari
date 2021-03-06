using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int lastDirection;
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
        Vector3 pos = transform.position;
 
         if (Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d"))  {
             pos.y += speed * Time.deltaTime;
             RotateSprite(0);
        }
         if (Input.GetKey ("s") && !Input.GetKey("a") && !Input.GetKey("d")) {
             pos.y -= speed * Time.deltaTime;
             RotateSprite(1);
        }
         if (Input.GetKey ("d") && !Input.GetKey("w") && !Input.GetKey("s")) {
             pos.x += speed * Time.deltaTime;
             RotateSprite(2);
        }
         if (Input.GetKey ("a") && !Input.GetKey("w") && !Input.GetKey("s")) {
             pos.x -= speed * Time.deltaTime;
             RotateSprite(3);
         }
         transform.position = pos;
    }

    void RotateSprite(int newDirection)
    {
        if(lastDirection == newDirection)
        {
            return;
        } 
        else
        {
            switch (newDirection)
            {
                //cases: 0 = up, 1 = down, 2 = right, 3 = left
                case 0:
                    spriteRenderer.sprite = spriteUp;
                    break;
                case 1:
                    spriteRenderer.sprite = spriteDown;
                    break;
                case 2:
                    spriteRenderer.sprite = spriteLeft;
                    spriteRenderer.flipX = true;
                    break;
                case 3:
                    spriteRenderer.sprite = spriteLeft;
                    spriteRenderer.flipX = false;
                    break;
            }
            lastDirection = newDirection;
            return;
        }
    }
}

