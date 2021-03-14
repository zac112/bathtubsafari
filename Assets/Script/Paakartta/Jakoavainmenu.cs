using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jakoavainmenu : MonoBehaviour
{
    [SerializeField]
    Jakoavain[] avaimet;
    int aktivoitu = 0;
    bool down = false;
    [SerializeField]
    Vector3 startPos;
    [SerializeField]
    Vector3 endPos;

    private void Awake()
    {
        aktivoitu = 0;
        down = false;
        gameObject.SetActive(true);
        transform.position = startPos;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
                
    }

    public void Aktivoi(GameObject activator) {
        try
        {
            avaimet[aktivoitu].Aktivoi(activator);
            aktivoitu++;
        }
        catch (System.Exception) {
            print("Let the man go already");
        }
    }

    private IEnumerator FloatDown() {
        float startTime = Time.time;
        float duration = 1f;
        if (down) {
            transform.position = endPos;
            yield break; 
        }
        down = true;

        while (Time.time < startTime + duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) / duration);
            yield return null;
        }

        yield return ActivateJakoavain();

    }

    private IEnumerator ActivateJakoavain() { 
        foreach (Jakoavain j in avaimet)
        {
            j.gameObject.SetActive(true);
            j.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
