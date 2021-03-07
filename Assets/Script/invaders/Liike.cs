﻿using System;
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

    // Start is called before the first frame update
    void Start()
    {
        pisarat = new List<GameObject>(GameObject.FindGameObjectsWithTag("InvadersPisara"));
        StartCoroutine("LopetaPeli");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += -1*transform.right*Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position +=  transform.right * Time.deltaTime * speed;
        }
        
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position +=  transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position +=  -1 * transform.up * Time.deltaTime * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Ammu();
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
        SceneManager.LoadScene("Paakartta");
    }
}
