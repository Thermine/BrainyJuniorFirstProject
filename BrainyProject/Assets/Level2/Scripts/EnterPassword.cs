using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterPassword : MonoBehaviour
{
    public string RightCombination; // правильная комбинация чисел
    public string PlayerCombination; // комбинация игрока
    public TMP_InputField InputField;


    public void EnterDigit(int digit) // ввод числа из UI
    {
        if(PlayerCombination.Length != RightCombination.Length)
        {
            PlayerCombination += digit.ToString();
            InputField.text = PlayerCombination;
            if(PlayerCombination.Length == RightCombination.Length)
            {
                StartCoroutine(Check());
            }
        }
    }
    IEnumerator Check()
    {
        if (PlayerCombination == RightCombination)
        {
            InputField.text = "Верная комбинация!";
            yield return new WaitForSeconds(1);
            RightComb();
            gameObject.SetActive(false);
        }
        else
        {
            InputField.text = "Неправильная комбинация!";
            yield return new WaitForSeconds(1);
            InputField.text = "";
            PlayerCombination = "";
        }
    }
    void RightComb()
    {
        print("Представили что лифт открываетс яи ты в него заходишь да...");
    }
}
