using System;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;

public class AudioZoneComponent : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    [SerializeField] private string audioId;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(triggerTag)) return;
        BackgroundMusicManager.Instance.PlayAudioById(audioId);
    }
}
