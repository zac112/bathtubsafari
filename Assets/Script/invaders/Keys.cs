using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Katoa");
    }

    // Update is called once per frame
    IEnumerator Katoa()
    {
        float startTime = Time.time;
        float duration = 7f;
        Vector3 startPos = transform.position;
        while (Time.time < startTime + duration) {
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.clear, Color.white, (Time.time - startTime) / duration);
            transform.position = Vector3.Lerp(startPos, Vector3.zero, (Time.time - startTime) / duration);
            yield return null;
        }

        Destroy(gameObject);
    }
}
