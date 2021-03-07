using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack() {
        SceneManager.LoadScene("Paakartta");
    }
}
