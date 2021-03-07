using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.hideFlags = HideFlags.DontSave;
    }

    public void Complete(Scene s) {
        foreach (GameObject go in points) {
            PointOfInterest poi = go.GetComponent<PointOfInterest>();
            if (poi.SceneIndex() == s.buildIndex){
                poi.SetPointVisible(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            SceneManager.LoadScene("Paakartta");
        }
    }

}
