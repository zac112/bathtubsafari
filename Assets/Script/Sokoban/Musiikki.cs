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
        musiikkiObjektit = GameObject.FindGameObjectsWithTag("Musiikki");
        if(musiikkiObjektit.Length > 1){
            Destroy(gameObject);
            return;
        }
        if(gameObject.tag.Equals("MenuMusiikki")){
            Destroy(GameObject.FindGameObjectWithTag("Musiikki"));
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    void awake()
    {

    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
 
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
