using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterPassword : MonoBehaviour
{
    public string RightCombination; // ���������� ���������� �����
    public string PlayerCombination; // ���������� ������
    public TMP_InputField InputField;
    public Animator LiftAnimator;

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
    [ContextMenu("EnterDigit")]
    public void digitEditor()
    {
        InputField.text = PlayerCombination;
        if (PlayerCombination.Length == RightCombination.Length)
        {
            StartCoroutine(Check());
        }
    }
    public IEnumerator Check()
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
            InputField.text = "������������ ������!";
            yield return new WaitForSeconds(1);
            InputField.text = "";
            PlayerCombination = "";
        }
    }
    void RightComb()
    {
        LiftAnimator.SetTrigger("Open");
        transform.parent.GetComponent<LiftScript>().AudioManager.PlayAudioById("OpenDoor");
        gameObject.SetActive(false);
    }
}
