using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musiikki : MonoBehaviour
{   
    private AudioSource audioSource;
    private GameObject[] musiikkiObjektit;
    // Start is called before the first frame update
    void Start()
    {   
        string tag = gameObject.tag;
        if(tag.Equals("Musiikki"))
        {
            //siirrytään menusta tasoon
            Korvaa("MenuMusiikki", "Musiikki");
        } 
        else if (tag.Equals("MenuMusiikki"))
        {   
            //siirrytään tasosta menuun
            Korvaa("Musiikki", "MenuMusiikki");
        }
    }

    void awake()
    {

    }

    void Korvaa(string poistettava, string haluttu){

        Destroy(GameObject.FindGameObjectWithTag(poistettava));
        musiikkiObjektit = GameObject.FindGameObjectsWithTag(haluttu);
        if(musiikkiObjektit.Length > 1){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
