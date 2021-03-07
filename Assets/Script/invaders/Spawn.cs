using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject pisara;
    [SerializeField]
    int spawnInterval;

    void Start()
    {
        StartCoroutine("SpawnDrops");
    }

    IEnumerator SpawnDrops() {
        yield return new WaitForSeconds(30f);
        while (true) {
            yield return CreateDrop();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator CreateDrop() {
        GameObject go = GameObject.Instantiate(pisara, transform.position, transform.rotation);
        go.GetComponent<Pisara>().enabled = false;
        go.transform.localScale = Vector3.zero;
        float startTime = Time.time;        
        float duration = 2f;
        float endTime = startTime + duration;

        while (Time.time < endTime) {
            float progress = (Time.time - startTime) / duration;
            Vector3 scale = Vector3.one*2 * progress;
            go.transform.localScale = scale;

            yield return null;
        }
        go.GetComponent<Pisara>().enabled = true;
    }
}
