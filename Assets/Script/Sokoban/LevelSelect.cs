using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    Button levelSelectButton;
    // Start is called before the first frame update
    void Start()
    {
        levelSelectButton = GameObject.Find("LevelSelect").GetComponent<Button>();
        levelSelectButton.onClick.AddListener(GoToLevelSelection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToLevelSelection() {
        Timer.secondsSinceStart = 0;
        SceneManager.LoadScene("TasoMenu");
    }
}
