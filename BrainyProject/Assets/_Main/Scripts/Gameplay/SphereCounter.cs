using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCounter : MonoBehaviour
{
    public static int ColCounter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SphereCounter.ColCounter++;
        }
    }
}
