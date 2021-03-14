using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    GameObject[] POIs;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;
        GameObject gm = GameObject.Find("GameManager");
        if (gm != null)
        {            
            if (gm.GetComponent<GameManager>().first)
            {                
                StartCoroutine("EntryAnimation");
            }
            else
            {
                transform.position = waypoint.transform.position;
                transform.rotation = waypoint.transform.rotation;
                GetComponent<Animator>().Play("Idle");
                huutomerkki.SetActive(false);
                Setup();
            }
            gm.GetComponent<GameManager>().first = false;
        }

        if (GameObject.Find("GameManager").GetComponent<GameManager>().GameIsFinished())
            StartCoroutine("OutroAnimation");

        GameObject m = GameObject.Find("Musiikki");
        if (m != null) {
            Destroy(m);
         }
    }

    void Setup() {
        huutomerkki.SetActive(false);
        nuoli.SetActive(true);
        nuoli2.SetActive(true);
        nuoli3.SetActive(true);
        GameObject.Find("Jakoavainmenu").GetComponent<Jakoavainmenu>().StartCoroutine("FloatDown");
        
        foreach (GameObject go in POIs)
        {
            go.SetActive(true);
        }
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

        Setup();

    }

    public IEnumerator OutroAnimation() {        
        float startTime = Time.time;
        float duration = 4f;
        while (Time.time < startTime + duration)
        {
            //transform.LookAt(waypoint.transform.position,transform.up);
            transform.rotation = Quaternion.Lerp(waypoint.transform.rotation, startPoint.transform.rotation, (Time.time - startTime) / duration);
            yield return null;
        } 

        GetComponent<Animator>().Play("Ukko");

        startTime = Time.time;
        duration = 2f;
        while (true)
        {
            //transform.LookAt(waypoint.transform.position,transform.up);
            transform.position = Vector3.Lerp(waypoint.transform.position, startPoint.transform.position, (Time.time - startTime) / duration);
            yield return null;
            if (Vector3.Distance(transform.position, startPoint.transform.position) < 0.01f)
            {
                break;
            }
        }
        GameObject.Find("Jakoavainmenu").SetActive(false);
        SceneManager.LoadScene("outro");
    }
}
