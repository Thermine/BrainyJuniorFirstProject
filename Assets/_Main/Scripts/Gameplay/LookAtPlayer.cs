using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform look;
    private void Start()
    {
        look = Camera.main.transform;
    }
    private void Update()
    {
       transform.LookAt(look);
    }
}
