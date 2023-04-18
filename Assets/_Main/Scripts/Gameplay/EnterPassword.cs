using System.Collections;
using BrainyJunior.MyGame.Scripts.Singleton;
using UnityEngine;
using TMPro;
using djastas;

public class EnterPassword : MonoBehaviour
{
    public string RightCombination; // ���������� ���������� �����
    public string PlayerCombination; // ���������� ������
    public TMP_InputField InputField;
    public Animator LiftAnimator;
    public string AudioID;

    
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
            InputField.text = "You're right!";
            yield return new WaitForSeconds(1);
            RightComb();
            gameObject.SetActive(false);
        }
        else
        {
            InputField.text = "Wrong!!!";
            yield return new WaitForSeconds(1);
            InputField.text = "";
            PlayerCombination = "";
        }
    }

    public IEnumerator FalseComb()
    {
        yield return new WaitForSeconds(15);
        AudioManager.Instance.PlayAudioById(AudioID);
        yield return new WaitForSeconds(40);
        transform.parent.GetComponent<LiftScript>().AsyncLoad.AsyncLoading(transform.parent.GetComponent<LiftScript>().SceneIndex);
    }
    void RightComb()
    {
        StopCoroutine(FalseComb());
        LiftAnimator.SetTrigger("Open");
        AudioManager.Instance.PlayAudioById("OpenDoor");
        gameObject.SetActive(false);
        transform.parent.GetComponent<BoxCollider>().enabled = true;
    }
}
