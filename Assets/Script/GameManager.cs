using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;

    static int counter;
    public int id;

    [SerializeField]
    int pisteet;

    public int voittopisteet = 7;

    public bool first = true;

    private void Awake()
    {
        first = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        voittopisteet = 7;
        id = counter;
        counter++;
        DontDestroyOnLoad(gameObject);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Respawn"))
        {
            if (go.GetComponent<GameManager>().id < this.id)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Complete(Scene s)
    {
        foreach (GameObject go in points)
        {
            PointOfInterest poi = go.GetComponent<PointOfInterest>();
            if (poi.SceneIndex() == s.buildIndex)
            {
                poi.SetPointVisible(true);
            }
        }
    }

    public void LisaaPiste(GameObject aktivaattori)
    {
        pisteet++;
        if (GameIsFinished()) {
            GetComponent<AudioSource>().time = 12;
            GetComponent<AudioSource>().Play(); 
        }
        print(pisteet + " " + voittopisteet);
        GameObject go = GameObject.Find("Jakoavainmenu");
        if (go != null) go.GetComponent<Jakoavainmenu>().Aktivoi(aktivaattori);
    }

    public void LisaaPiste()
    {
        LisaaPiste(null);
    }

    public bool GameIsFinished() {
        return pisteet >= 7;
    }
}
