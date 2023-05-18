using BrainyJunior.MyGame.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHelper : MonoBehaviour
{
    [SerializeField] private Toggle AnotherTogle;
    public static string Gender = "Boy";
    [SerializeField] private Registration_0LVL Registration_0LVL;
    [SerializeField] private SaveDataInFileManager saveDataInFile;

    public void OnChangeValue(string MyGender)
    {
        AnotherTogle.isOn = !GetComponent<Toggle>().isOn;
        ToggleHelper.Gender = MyGender;
    }

    public void SumbitGender()
    {
        BackgroundMusicManager.Instance.PlayAudioById("103");
        saveDataInFile.WriteCsv(ToggleHelper.Gender);
    }
}
