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
    static bool timerState = true;
    public static float secondsSinceStart;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        StartCoroutine("Ajastin");
    }

    void FixedUpdate() {
        if (timerState) {
            minutes = Mathf.FloorToInt(secondsSinceStart / 60);
            seconds = Mathf.FloorToInt(secondsSinceStart % 60);
            
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    public static void TurnTimerOff() {
        timerState = false;
    }

    public static void TurnTimerOn() {
        timerState = true;
    }

    IEnumerator Ajastin(){
        while(true){
            yield return new WaitForSeconds(1f);
            secondsSinceStart++;
   }
}
}
