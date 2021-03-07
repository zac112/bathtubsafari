using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ankkascript : MonoBehaviour
{
    enum Selection { INTRO, GAME, CREDITS};

    [SerializeField]
    Selection scene;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.right, 0.5f);

        if (Input.anyKeyDown) {
            switch (scene) {
                case Selection.INTRO: { 
                        SceneManager.LoadScene("Intro"); 
                        break; 
                    }
                case Selection.GAME: { 
                        GameObject.Find("ukko").SetActive(true); 
                        Destroy(transform.parent.gameObject);
                        break;
                    }
                case Selection.CREDITS: {
                        break;
                    }

            }

        }
    }
}
