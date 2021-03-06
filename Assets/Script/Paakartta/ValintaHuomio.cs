using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValintaHuomio : MonoBehaviour
{
    // Täytyiskö tässä luoda siis se "sijainti", sillee new Vector3. Ei, koska tämä on vaan se liike?  emt. tutkitaan
    // transform.position = new Vector3(x, y, z); mut tonne starttiin siis? tai ihan vaan
    // Vector3 sijainti;

    float aikaLiikkeenValissa = 1f;

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
            transform.position += new Vector3(0f, 1f, 0f);
            yield return new WaitForSeconds(aikaLiikkeenValissa);
            transform.position += new Vector3(0f, -1f, 0f);
            yield return new WaitForSeconds(aikaLiikkeenValissa);
        }
    }
}
