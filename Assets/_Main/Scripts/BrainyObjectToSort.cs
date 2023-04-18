using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Core;

public class BrainyObjectToSort : MonoBehaviour
{
    [Header("Local tools"), SerializeField, Tooltip("Name of container that is right for this object")] private string _containerTag;

    [Space(5)]

    [Header("Database tools"), SerializeField, Tooltip("Object name that we send to the database")] private string _databaseObjectName;



    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject && other.gameObject.CompareTag(_containerTag)) // this item & container trigger
        {
            this.gameObject.GetComponent<HVRGrabbable>().enabled = false; //there we are turning off an ability to grab this object in future
        }
    }
}
