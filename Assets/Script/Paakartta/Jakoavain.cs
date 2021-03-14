using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jakoavain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Rotate");
    }

    // Update is called once per frame
    IEnumerator Rotate()
    {
        while (true)
        {
            float rotation = Mathf.Sin(Time.time);
            transform.localRotation = Quaternion.Euler(0, 0, rotation * 360f);
            yield return null;
        }
    }

    public void Aktivoi(GameObject activator) {
        transform.position -= new Vector3(0, 0, 2);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;

        //StartCoroutine("DoActivate");        
    }
    /*
    private IEnumerator DoActivate()
    {
        
            float startTime = Time.time;
            float duration = 2f;
            Vector3 startPos = activator.transform.position;
            while (Time.time < startTime + duration)
            {
                activator.transform.position = Vector3.Slerp(startPos, transform.position, Time.time / (startTime + duration));
                yield return null;
            }

            activator.transform.position = transform.position;

            yield return new WaitUntil(() => Mathf.Approximately(Mathf.Sin(Time.time), 0f));
            Destroy(activator);
        
        transform.position -= new Vector3(0, 0, 2);
    }*/
}
