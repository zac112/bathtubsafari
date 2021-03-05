using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointOfInterest : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    void OnMouseDown() {
        SceneManager.LoadScene(sceneName);
    }
}
