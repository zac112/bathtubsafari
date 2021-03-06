using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolvedCheck : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void checkWin() {
        bool hole1 = GameObject.Find("Hole1").GetComponent<PlugTile>().getIsPlugged();
        bool hole2 = GameObject.Find("Hole2").GetComponent<PlugTile>().getIsPlugged();
        bool hole3 = GameObject.Find("Hole3").GetComponent<PlugTile>().getIsPlugged();

        if (hole1 & hole2 & hole3) {
            print("Epic");
            Timer.TurnTimerOff();
        }
    }
}
