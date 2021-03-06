using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisara : MonoBehaviour
{
    bool left = true;
    float Yoffset = 0.2f;
    [SerializeField]
    GameObject[] reunat;

    // Start is called before the first frame update
    void Start()
    {
        reunat = GameObject.FindGameObjectsWithTag("InvadersReuna");
    }

    public void ChangeDirection(bool left)
    {
        this.left = left;
    }

    public void AddOffset() {
        transform.position += transform.up * -Yoffset;
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = -1f;
        if (!left) {
            multiplier = 1f;
        }

        transform.position += transform.right * multiplier*Time.deltaTime;
    }

}
