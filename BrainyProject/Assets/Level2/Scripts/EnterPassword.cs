using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterPassword : MonoBehaviour
{
    public string RightCombination; // ���������� ���������� �����
    public string PlayerCombination; // ���������� ������
    public TMP_InputField InputField;


    public void EnterDigit(int digit) // ���� ����� �� UI
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
            InputField.text = "������ ����������!";
            yield return new WaitForSeconds(1);
            RightComb();
            gameObject.SetActive(false);
        }
        else
        {
            InputField.text = "������������ ����������!";
            yield return new WaitForSeconds(1);
            InputField.text = "";
            PlayerCombination = "";
        }
    }
    void RightComb()
    {
        print("����������� ��� ���� ���������� �� �� � ���� �������� ��...");
    }
}
