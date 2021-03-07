using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : MonoBehaviour
{

    [SerializeField]
    GameObject[] waypoints;
    [SerializeField] 
    GameObject next;
    [SerializeField]
    float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");   
    }

    IEnumerator Intro() {
        yield return new WaitForSeconds(delay);
        yield return GoToWaypoint(waypoints[0]);
        yield return new WaitForSeconds(2);
        yield return GoToWaypoint(waypoints[1]);
        if (next != null) {
            next.SetActive(true);
        }
    }

    IEnumerator GoToWaypoint(GameObject wp) {

        float start = Time.time;
        float duration = 4;
        Vector3 startPos = transform.position;
        Quaternion rot = transform.rotation;

        while(Time.time < start + duration)
        {
            transform.position = Vector3.Lerp(startPos, wp.transform.position, (Time.time-start)/duration);
            transform.rotation = Quaternion.Lerp(rot, wp.transform.rotation, (Time.time - start) / duration);
            yield return null;
        }
    }
}
