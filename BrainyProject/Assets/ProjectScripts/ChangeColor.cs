using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Material[] materials;
    
    public void ScaleObject(float num, float scaleObj)
    {
        float maxObj = scaleObj;
        float minObj = scaleObj / 2;

        Debug.Log("����" + maxObj);
        Debug.Log("���" + minObj);

        
        if (num <= maxObj && minObj <= num)
        {
            if (num == maxObj)
            {
                Debug.Log("������ �� �������");
                
            }
            else
            {
                Debug.Log("������ �� ������");
                //FindObjectOfType<MaterialController>().ColorYellow();
            }
        }
        else
        {
            Debug.Log("������ �� �������");
            //FindObjectOfType<MaterialController>().ColorRed();
        }
    }

}
