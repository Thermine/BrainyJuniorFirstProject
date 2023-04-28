using BrainyJunior.MyGame.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Registration_0LVL : MonoBehaviour
{
    public SaveDataInFileManager SaveDataInFileManager;
    [SerializeField] private List<InputField> Fields = new List<InputField>();
    private int FieldIndex;
    private string Info;
    private InputField currentField;
    [SerializeField] private KeyboardScript Keyboard;     
    [SerializeField] Button TurnOffButton;

    private void Start()
    {
        currentField = Fields[0];
        Info = "";
    }
    public void SwitchField()
    {
        if(currentField.text != "")
        {
            if (FieldIndex < Fields.Count)
            { 
                SumbitInfo();
                FieldIndex++;
                currentField = Fields[FieldIndex];
                Keyboard.TextField = currentField;
            }
            else
            {
                TurnOffButton.interactable = true;
            }
        }

    }

    public void SumbitInfo()
    {
        if(Info != currentField.text)
        {
            Info = currentField.text;
            SaveDataInFileManager.WriteCsv(Info);
        }

    }
}
