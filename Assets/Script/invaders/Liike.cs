using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Liike : MonoBehaviour
{

    [SerializeField]
    GameObject ammus;
    [SerializeField]
    int latausAika = 1;
    [SerializeField]
    public static List<GameObject> pisarat;
    [SerializeField]
    float speed = 1f;

    bool voiAmpua = true;
    bool liikkeessa = false;
    [SerializeField]
    GameObject voitto;
    // Start is called before the first frame update
    void Start()
    {
        pisarat = new List<GameObject>(GameObject.FindGameObjectsWithTag("InvadersPisara"));
        StartCoroutine("LopetaPeli");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
            liikkeessa = true;
        else { 
            liikkeessa = false;
            GetComponent<AudioSource>().Pause();
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position += -1*transform.right*Time.deltaTime * speed;
            liikkeessa = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position +=  transform.right * Time.deltaTime * speed;
            liikkeessa = true;
        }
        
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position +=  transform.up * Time.deltaTime * speed;
            liikkeessa = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position +=  -1 * transform.up * Time.deltaTime * speed;
            liikkeessa = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Ammu();
        }

        if (Input.GetKeyDown(KeyCode.U))
            pisarat.Clear();

        if (liikkeessa && !GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().Play();
        }
    }

    internal void ActivateShootingSpeed()
    {
        latausAika = latausAika / 2;
    }

    internal void ActivateMovementSpeed()
    {
        speed *= 2f; 
    }

    private void Ammu() {
        if (voiAmpua) {
            GameObject a = GameObject.Instantiate(ammus,transform.position, transform.rotation);
            a.GetComponent<Ammus>().setPisarat(pisarat);
            voiAmpua = false;
            StartCoroutine("Lataa");
        }
    }

    IEnumerator Lataa() {
        yield return new WaitForSeconds(latausAika);
        voiAmpua = true;
    }

    IEnumerator LopetaPeli() {
        yield return new WaitUntil(() => pisarat.Count == 0);
        Destroy(GameObject.Find("Spawn point"));
        yield return NaytaVoittoteksti();

        SceneManager.LoadScene("Paakartta");
    }

    private IEnumerator NaytaVoittoteksti()
    {        
        voitto.transform.localScale = Vector3.zero;
        voitto.SetActive(true);

        float startTime = Time.time;
        float duration = 5f;
        while (Time.time < startTime + duration) {
            voitto.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 2, (Time.time - startTime) / duration);
            yield return null;
        }
        yield return new WaitForSeconds(5);

    }
}
