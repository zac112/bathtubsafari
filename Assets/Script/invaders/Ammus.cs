using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammus : MonoBehaviour
{
    List<GameObject> pisarat;

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
        pisarat.Remove(collider.gameObject);
        Destroy(gameObject);
        Destroy(collider.gameObject);
    }
}
