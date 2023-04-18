using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject responce;
    public GameObject platform;



    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject && other.gameObject.CompareTag("Player"))
        {
            responce.SetActive(true);
            Destroy(platform);
        }
    }
}
