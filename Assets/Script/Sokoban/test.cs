using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class test : MonoBehaviour
{
    void Start()
    {
        muutaVari();
    }
    private static Dictionary<int,bool> lapaistytTasot = new Dictionary<int, bool>();
    public static void isSolved(){
        if(!(SceneManager.GetActiveScene().buildIndex==3))
            lapaistytTasot.Add((SceneManager.GetActiveScene().buildIndex-3),true);
    }
    public static void muutaVari(){
        foreach(var i in lapaistytTasot){
            GameObject.Find("TasoEntry"+i.Key).GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
        }
    }

}
