using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using djastas;

public class EnterPassword : MonoBehaviour
{
    public string RightCombination; // правильная комбинация чисел
    public string PlayerCombination; // комбинация игрока
    public TMP_InputField InputField;
    public Animator LiftAnimator;
    AudioManager AudioManager;
    public string AudioID;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
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
            InputField.text = "Верная комбинация!";
            yield return new WaitForSeconds(1);
            RightComb();
            gameObject.SetActive(false);
        }
        else
        {
            InputField.text = "Неправильный пароль!";
            yield return new WaitForSeconds(1);
            InputField.text = "";
            PlayerCombination = "";
        }
    }

    public IEnumerator FalseComb()
    {
        yield return new WaitForSeconds(15);
        AudioManager.PlayAudioById(AudioID);
        yield return new WaitForSeconds(40);
        transform.parent.GetComponent<LiftScript>().AsyncLoad.AsyncLoading(transform.parent.GetComponent<LiftScript>().SceneIndex);
    }
    void RightComb()
    {
        StopCoroutine(FalseComb());
        LiftAnimator.SetTrigger("Open");
        transform.parent.GetComponent<LiftScript>().AudioManager.PlayAudioById("OpenDoor");
        gameObject.SetActive(false);
    }
}
