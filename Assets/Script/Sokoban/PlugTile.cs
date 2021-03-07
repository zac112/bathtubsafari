using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugTile : MonoBehaviour
{
    [SerializeField]
    bool isPlugged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "PlugTile") 
        {
            isPlugged = true;
            SolvedCheck.checkWin();
        }

    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "PlugTile") 
        {
            isPlugged = false;
        }
    }

    public bool getIsPlugged() {
        return isPlugged;
    }
}
