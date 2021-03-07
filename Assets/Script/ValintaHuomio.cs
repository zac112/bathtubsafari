using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValintaHuomio : MonoBehaviour
{

    public float aikaLiikkeenValissa = 1f;
    public float liike = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LiikeYlosAlas");
    }


    
    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator LiikeYlosAlas()
    {
        while (true)
        {
            transform.position += new Vector3(0f, liike, 0f);
            yield return new WaitForSeconds(aikaLiikkeenValissa);
            transform.position += new Vector3(0f, -liike, 0f);
            yield return new WaitForSeconds(aikaLiikkeenValissa);
        }
    }
}
