using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject pisara;
    [SerializeField]
    int spawnInterval;
    bool running = false;

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
        go.GetComponent<CapsuleCollider2D>().enabled = false;
        go.transform.localScale = Vector3.zero;
        Liike.pisarat.Add(go);
        float startTime = Time.time;        
        float duration = 2f;
        float endTime = startTime + duration;

        while (Time.time < endTime) {
            float progress = (Time.time - startTime) / duration;
            Vector3 scale = Vector3.one*2 * progress;
            go.transform.localScale = scale;
            go.transform.position -= transform.up * Time.deltaTime/2;

            yield return null;
        }
        go.GetComponent<Pisara>().enabled = true;
        go.GetComponent<Pisara>().moving = true;
        go.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    public IEnumerator CreateEndDrop()
    {
        if (!running) {
            StartCoroutine("ChangeMap");
            running = true;
        }
        GameObject go = GameObject.Instantiate(pisara, transform.position, transform.rotation);
        go.GetComponent<Pisara>().enabled = false;
        go.GetComponent<CapsuleCollider2D>().enabled = false;
        go.transform.localScale = Vector3.zero;
        Liike.pisarat.Add(go);
        float startTime = Time.time;
        float duration = 5f;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / duration;
            go.transform.localScale = Vector3.Slerp(Vector3.zero,Vector3.one*50,progress);
            go.transform.position -= transform.up * Time.deltaTime;

            yield return null;
        }        

    }

    IEnumerator ChangeMap()
    {
        yield return new WaitForSeconds(5);
        Pisara.alku = true;
        SceneManager.LoadScene("Paakartta");
    }
}
