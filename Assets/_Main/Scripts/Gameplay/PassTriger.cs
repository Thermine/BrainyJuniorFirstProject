using BrainyJunior.MyGame.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BackgroundMusicManager.Instance.PlayAudioById("123");
        }
    }
}
