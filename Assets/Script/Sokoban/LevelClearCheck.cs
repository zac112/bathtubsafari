using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelClearCheck : MonoBehaviour
{
    void Start()
    {
        muutaVari();
    }
    private static Dictionary<int,bool> lapaistytTasot = new Dictionary<int, bool>();
    public static void isSolved(){
        if (!(SceneManager.GetActiveScene().buildIndex == 3) && !lapaistytTasot.ContainsKey(SceneManager.GetActiveScene().buildIndex - 3))
        {
            lapaistytTasot.Add((SceneManager.GetActiveScene().buildIndex - 3), true);
            GameObject go = GameObject.Find("GameManager");
            if (go != null) go.GetComponent<GameManager>().LisaaPiste();
        }
    }
    public static void muutaVari(){
        foreach(var i in lapaistytTasot){
            GameObject go = GameObject.Find("TasoEntry" + i.Key);
            go.GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
            GameObject wrench = go.transform.Find("wrench").gameObject;
            wrench.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            wrench.GetComponent<Jakoavain>().enabled = false;
        }
    }

}
