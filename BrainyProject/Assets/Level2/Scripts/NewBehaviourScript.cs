using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform look;

    private void Update()
    {
       transform.LookAt(look);
    }
}
