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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float secondsSinceStart = Mathf.Round(Time.unscaledTime);
        minutes = Mathf.FloorToInt(secondsSinceStart / 60);
        seconds = Mathf.FloorToInt(secondsSinceStart % 60);
        
    }
}
