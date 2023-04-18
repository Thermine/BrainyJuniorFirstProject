using Pixelcrew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadSphereCol : MonoBehaviour
{
    [SerializeField] private SaveDataInFileComponent SaveDataInFileComponent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveDataInFileComponent.WriteCsv(SphereCounter.ColCounter.ToString());
        }
    }
}
