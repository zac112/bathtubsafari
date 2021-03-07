using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] boosts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBoost");
    }

    private IEnumerator SpawnBoost() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(5, 20));
            Spawn();
        }
    }
    
    private void Spawn()
    {
        BoxCollider2D area = transform.GetComponentInChildren<BoxCollider2D>();
        int index = (int)Random.Range( 0, boosts.Length + 1) % boosts.Length;
        float x = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float y = Random.Range(area.bounds.min.y, area.bounds.max.y);
        float z = transform.position.z;

        GameObject go = GameObject.Instantiate(boosts[index], new Vector3(x,y,z), transform.rotation);

    }
}
