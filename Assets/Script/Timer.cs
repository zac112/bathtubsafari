using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    [SerializeField]
    int minutes;
    [SerializeField]
    int seconds;
    [SerializeField]
    Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float secondsSinceStart = Mathf.Round(Time.unscaledTime);
        minutes = Mathf.FloorToInt(secondsSinceStart / 60);
        seconds = Mathf.FloorToInt(secondsSinceStart % 60);
        
        timer.text = "win";
        print(timer.text);
    }
}
