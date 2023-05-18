using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainyJunior.MyGame.Scripts.Managers;

public class ShootingDotsManager : MonoBehaviour
{
    private int shootedDotsCount = 0;
    [SerializeField]
    private string audioId;
    public BackgroundMusicManager manager;

    public void DestroyDot()
    {
        shootedDotsCount += 1;
        if(shootedDotsCount >= 10)
        {
            manager.PlayAudioById(audioId);
        }
    }
}
