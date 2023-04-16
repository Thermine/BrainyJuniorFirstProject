using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FootStep : MonoBehaviour
{
    public ObjectSwitcher ObjectSwitcher;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ObjectSwitcher.Starting();
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
