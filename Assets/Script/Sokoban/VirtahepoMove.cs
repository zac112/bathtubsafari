using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtahepoMove : MonoBehaviour
{

    [SerializeField]
    Vector3 startVector;
    [SerializeField]
    Vector3 endVector;
    [SerializeField]
    float speed;
    bool startToEnd = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (startToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endVector, Time.deltaTime * speed);

            if (transform.position == endVector)
            {
                TurnBack();
            }

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startVector, Time.deltaTime * speed);

            if (transform.position == startVector)
            {
                TurnBack();
            }
        }

    }

    void TurnBack()
    {
        startToEnd = !startToEnd;
        transform. Rotate(new Vector3(0,180,0));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        TurnBack();
    }
}
