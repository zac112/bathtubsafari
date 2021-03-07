using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralizePlug : MonoBehaviour
{
    [SerializeField] float plugDistance = 0.1f;
    [SerializeField] float unPlugDistance = 0.2f;
    private bool isPlugged = false;
    void Start()
    {
        
    }

    void Update()
    {
        GameObject nearest = FindNearestHole();
        float distance = DistanceToNearest();
        
        if (distance < plugDistance && !isPlugged)
        {
            transform.position = nearest.transform.position;
            isPlugged = true;
        }

        if (distance > unPlugDistance)
        {
            isPlugged = false;
        }
       
        

    }

    // Etsii lähimpänä olevan holen ja palauttaa sen
    public GameObject FindNearestHole() 
    {
        GameObject[] holes;
        holes = GameObject.FindGameObjectsWithTag("Hole");
        GameObject nearest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject hole in holes)
        {
            Vector3 difference = hole.transform.position - position;
            float currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance) 
            {
                nearest = hole;
                distance = currentDistance;
            }
        }
        return nearest;
    }

    public float DistanceToNearest() 
    {
        GameObject nearest = FindNearestHole();
        Vector3 position = transform.position;
        Vector3 difference = nearest.transform.position - position;
        float distance = difference.sqrMagnitude;
        return distance;
    }
}
