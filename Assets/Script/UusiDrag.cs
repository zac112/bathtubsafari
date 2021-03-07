using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UusiDrag : MonoBehaviour
{

    Vector3 lastPos;
    bool isheld = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isheld = true;
    }

    private void FixedUpdate()
    {
        if (isheld) { 
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x - lastPos.x, pos.y - lastPos.y)*10f);
            //lastPos = pos;

            GetComponent<Rigidbody2D>().MovePosition(new Vector2(pos.x, pos.y));
            lastPos = pos;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isheld = false;
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(lastPos.x, lastPos.y));
        //transform.position = new Vector3(lastPos.x,lastPos.y,0);
    }
    private void OnMouseUp()
    {
        isheld = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
