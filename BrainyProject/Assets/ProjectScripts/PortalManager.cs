using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    [SerializeField] private GameObject responce;


    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.CompareTag("Portal") && other.gameObject.CompareTag("Player"))
        {


            responce.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
