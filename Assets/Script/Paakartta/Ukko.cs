using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ukko : MonoBehaviour
{
    [SerializeField]
    GameObject waypoint;
    [SerializeField]
    GameObject startPoint;
    [SerializeField]
    GameObject huutomerkki;
    [SerializeField]
    GameObject nuoli;
    [SerializeField]
    GameObject nuoli2;
    [SerializeField]
    GameObject nuoli3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;
        StartCoroutine("EntryAnimation");
    }

    IEnumerator EntryAnimation() {
        float startTime = Time.time;
        float duration = 4f;
        while (true)
        {
            //transform.LookAt(waypoint.transform.position,transform.up);
            transform.position = Vector3.Lerp(startPoint.transform.position, waypoint.transform.position, (Time.time - startTime) / duration);
            yield return null;
            if (Vector3.Distance(transform.position, waypoint.transform.position) < 0.01f) {
                break;
            }
        }

        GetComponent<Animator>().Play("Idle");

        startTime = Time.time;
        duration = 2f;
        while (Time.time < startTime+duration)
        {
            //transform.LookAt(waypoint.transform.position,transform.up);
            transform.rotation = Quaternion.Lerp(startPoint.transform.rotation, waypoint.transform.rotation, (Time.time - startTime) / duration);
            yield return null;
        }

        huutomerkki.SetActive(true);
        Color c = huutomerkki.GetComponent<SpriteRenderer>().color;
        float a = 0f;
        huutomerkki.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, a);

        startTime = Time.time;
        duration = 1f;
        while (huutomerkki.GetComponent<SpriteRenderer>().color.a < 1f)
        {            
            huutomerkki.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.clear, Color.white, (Time.time - startTime) / duration);
            yield return null;
        }
        yield return new WaitForSeconds(6);
        huutomerkki.SetActive(false);
        nuoli.SetActive(true);
        nuoli2.SetActive(true);
        nuoli3.SetActive(true);
    }
}
