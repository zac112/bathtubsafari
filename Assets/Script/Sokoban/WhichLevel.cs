using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhichLevel : MonoBehaviour
{
    [SerializeField]
    Text levelText;
    // Start is called before the first frame update
    void Start()
    {   
        Regex rx = new Regex("[0-9]");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        string activeScene = SceneManager.GetActiveScene().name;
        string levelNumber = "";
        if(activeScene.Equals("Tutoriaali")) {
            levelNumber = "Tutorial";
        } else {
            foreach(char c in activeScene) {
                string s = ""+c;
                if (rx.IsMatch(s))
                {
                    levelNumber += s;
                }
            }
        }
        levelText.text = "Level " + levelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
