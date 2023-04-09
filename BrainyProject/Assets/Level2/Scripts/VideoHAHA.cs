using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoHAHA : MonoBehaviour
{
    public GameObject video;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            video.SetActive(true);
        }
    }
}
