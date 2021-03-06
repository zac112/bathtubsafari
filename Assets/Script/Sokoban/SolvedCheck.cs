using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SolvedCheck : MonoBehaviour
{
    static GameObject[] holes;
    static bool filled;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void checkWin()
    {
        filled = true;
        holes = GameObject.FindGameObjectsWithTag("Hole");

        foreach (GameObject hole in holes)
        {
            if (!hole.GetComponent<PlugTile>().getIsPlugged())
            {
                filled = false;
            }
            else
            {
                continue;
            }
        }

        if (filled)
        {   
            Timer.secondsSinceStart = 0;
            if(SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1) {
                SceneManager.LoadScene("TasoMenu");
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
