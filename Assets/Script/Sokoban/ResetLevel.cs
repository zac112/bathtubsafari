using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Button resetLevelButton;
    void Start()
    {
        resetLevelButton = GameObject.Find("ResetLevel").GetComponent<Button>();
        resetLevelButton.onClick.AddListener(ResetCurrentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCurrentLevel()
    {  

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
