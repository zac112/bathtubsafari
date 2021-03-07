using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisaatio : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("GameManager"));
        GameObject go = new GameObject();
        go.name = "GameManager";
        GameManager g = go.AddComponent<GameManager>();
        DontDestroyOnLoad(go);
        g.voittopisteet = 7;

    }

}
