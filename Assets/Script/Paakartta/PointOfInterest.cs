using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointOfInterest : MonoBehaviour
{
    [SerializeField]
    int scene;
    bool visible;

    //Start StartCoroutine("Liike")

    void OnMouseDown() {
        SceneManager.LoadScene(scene);
    }

    public int SceneIndex() {
        return scene;
    }

    public void SetPointVisible(bool visible) {
        this.visible = visible;
        gameObject.SetActive(visible);
    }

}
