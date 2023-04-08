using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private InputField _inputName;

    [SerializeField]
    private InputField _inputAge;

    [SerializeField]
    private InputField _inputKnowledge;

    [SerializeField]
    private InputField _inputSex;

    int age;
    int knowledge;

    private Bd db;


    void Start()
    {
        db = GetComponent<Bd>();
    }


    public void Button()
    {
        age = int.Parse(_inputAge.text);
        knowledge = int.Parse(_inputKnowledge.text);
        db.SaveData(_inputName.text, age, knowledge, _inputSex.text);
    }
}
