using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapominanie : MonoBehaviour
{
    public string FullVvod;
    public ObjectSwitcher ObjectSwitcher;
    int amount;
    public GameObject[] btns;
    public int num;
    public void vvod(string type)
    {
        amount += 1;
        if (amount <= ObjectSwitcher.images.Count)
        {
            FullVvod += " " + type;
        }
        if (amount == ObjectSwitcher.images.Count)
        {
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].SetActive(false);
        }
    }
}
