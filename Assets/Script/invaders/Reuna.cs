using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reuna : MonoBehaviour
{
    
    public bool left = true;
    int triggers = 0;

    private void Start()
    {
        StartCoroutine("Trigger");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggers += 1;
    }

    IEnumerator Trigger() {
        while (true) {
            
            yield return new WaitUntil(() => triggers > 0);
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("InvadersPisara"))
            {
                go.GetComponent<Pisara>().ChangeDirection(left);
                go.GetComponent<Pisara>().AddOffset();

            }
            triggers = 0;
            yield return null; 
        }
    }
}
