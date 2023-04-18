using Pixelcrew;
using System.Collections;
using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadSphereCol : MonoBehaviour
{
    [SerializeField] private SaveDataInFileManager SaveDataInFileComponent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveDataInFileComponent.WriteCsv(SphereCounter.ColCounter.ToString());
        }
    }
}
