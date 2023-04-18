using Pixelcrew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRemembering : MonoBehaviour
{
    public string Player_Combination;
    public ObjectSwitcher ObjectSwitcher;
    public int amount;
    public GameObject[] btns;
    SaveDataInFileComponent SaveDataInFileComponent;
    private void Start()
    {
        SaveDataInFileComponent = GameObject.FindWithTag("DataSaver").GetComponent<SaveDataInFileComponent>();
    }
    public void vvod(string type)
    {
        if (amount < ObjectSwitcher.FigureIndexess.Count)
        {
            Player_Combination += " " + type;
        }   
        amount += 1;
        if (amount == ObjectSwitcher.FigureIndexess.Count)
        {
            StartCoroutine(wait());
        }
    }
    [ContextMenu("Chech")]
    public void VvodEditor()
    {
            amount+=1;
            if (amount == ObjectSwitcher.FigureIndexess.Count)
            {
                StartCoroutine(wait());
            }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].SetActive(false);
        }
        SaveDataInFileComponent.WriteCsv(Player_Combination);

    }
}
