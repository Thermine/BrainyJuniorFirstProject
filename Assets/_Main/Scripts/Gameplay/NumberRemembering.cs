using Pixelcrew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRemembering : MonoBehaviour
{
    [SerializeField] private string Player_Combination;
    [SerializeField] private ObjectSwitcher ObjectSwitcher;
    [SerializeField] private int amount;
    [SerializeField] private GameObject[] btns;
    private SaveDataInFileComponent SaveDataInFileComponent;
    private void Start()
    {
        SaveDataInFileComponent = GameObject.FindObjectOfType<SaveDataInFileComponent>();
    }
    public void EnterFigure(string type)
    {
        if (amount < ObjectSwitcher.FigureIndexess.Count)
        {
            Player_Combination += $",{type}";
        }   
        amount += 1;
        if (amount == ObjectSwitcher.FigureIndexess.Count)
        {
            StartCoroutine(Wait());
        }
    }
    [ContextMenu("Chech")]
    public void EnterFigureEditor()
    {
            amount+=1;
            if (amount == ObjectSwitcher.FigureIndexess.Count)
            {
                StartCoroutine(Wait());
            }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].SetActive(false);
        }
        SaveDataInFileComponent.WriteCsv(Player_Combination);

    }
}
