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

    float multiplier = -1f;

    public static bool speedDebuff = false;

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
        StartCoroutine("MoveDown");
        //transform.position += transform.up * -Yoffset;
    }

    private IEnumerator MoveDown() {
        float start = multiplier;
        float end = -multiplier;
        float duration = 1f;

        float startTime = Time.time;
        float endTime = Time.time+duration;

        float startY = transform.position.y;
        float endY = transform.position.y-Yoffset;

        while (Time.time - startTime < duration) {
            multiplier = Mathf.Lerp(start, end, (Time.time-startTime) / duration);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, endY, (Time.time - startTime) / duration), transform.position.z);
            yield return null;
        }


    }
    // Update is called once per frame
    void Update() {
        if (speedDebuff)
        {
            transform.position += transform.right * multiplier/2 * Time.deltaTime;
        }
        else {
            transform.position += transform.right * multiplier * Time.deltaTime;
        }
    }

}
