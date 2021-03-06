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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pisarat.Remove(collision.gameObject);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
