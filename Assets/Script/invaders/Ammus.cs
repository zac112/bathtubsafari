using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammus : MonoBehaviour
{
    List<GameObject> pisarat;

    [SerializeField]
    List<AudioClip> klipit;


    AudioSource audioplayer;
    private void Start()
    {
        audioplayer = GetComponent<AudioSource>();
        audioplayer.PlayOneShot(klipit[0]);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime;
    }

    public void setPisarat(List<GameObject> pisarat) {
        this.pisarat = pisarat;
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        audioplayer.PlayOneShot(klipit[1]);
        pisarat.Remove(collider.gameObject);
        transform.position = new Vector3(100, 100, 100);
        Destroy(gameObject,1f);
        Destroy(collider.gameObject);
    }
}
