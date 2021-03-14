using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAwarder : MonoBehaviour
{
    [SerializeField]
    GameObject wrench;


    // Update is called once per frame
    void AwardPoint()
    {
        if (wrench == null) return;

        GameObject menu = GameObject.Find("Jakoavainmenu");
        if(menu != null)
        {
            menu.GetComponent<Jakoavainmenu>().Aktivoi(wrench);
        }

    }
}
