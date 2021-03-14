using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endtext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine("Resize");
    }

    private IEnumerator Resize() {

        float start = Time.time;
        float duration = 2;
        float time = 0;
        while (Time.time < start + duration)
        {
            transform.rotation = Quaternion.Euler(Vector3.one * Mathf.Sin(Time.time)*2);
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one*2, time/duration);
            time += Time.deltaTime;
            yield return null;
        }
        
        while(true)
        //while (Vector3.Distance(transform.localEulerAngles, Vector3.zero) > 0.001f)
        {
            transform.rotation = Quaternion.Euler(Vector3.one * Mathf.Sin(Time.time));
            yield return null;
        }

    }
}
