using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    void Update()
    {
        float value = Mathf.Sin(Time.time)+3f;
        transform.localScale = new Vector3(value,value,value);
    }
}
