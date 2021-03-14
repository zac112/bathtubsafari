using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisaatio : MonoBehaviour
{

    [SerializeField]
    GameObject gameManager;
    [SerializeField]
    GameObject menu;

    void Start()
    {
        if (GameObject.Find("GameManager") == null) {
            GameObject go = GameObject.Instantiate(gameManager);
            go.name = "GameManager";
            GameManager g = go.AddComponent<GameManager>();
            DontDestroyOnLoad(go);
            g.voittopisteet = 7; 
        }

        if (GameObject.Find("Jakoavainmenu") == null)
        {
            GameObject go = GameObject.Instantiate(menu,new Vector3(2.33f, 5f,0), Quaternion.identity);
            go.name = "Jakoavainmenu";
            DontDestroyOnLoad(go);
        }

    }

}
