using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralizePlug : MonoBehaviour
{
    [SerializeField] float plugDistance; // Etäisyys, jonka päästä tulppa siirtyy reijän keskelle
    [SerializeField] float unPlugDistance; // Etäisyys, jonka päähän tulppa on siirrettävä, jotta tulppa voi siirtyä reijän keskelle
    [SerializeField] AudioSource audioSource;
    private bool isPlugged = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GameObject nearest = FindNearestHole();
        float distance = DistanceToNearest();
        
        if (distance < plugDistance && !isPlugged)
        {
            transform.position = nearest.transform.position;
            audioSource.Play();
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
