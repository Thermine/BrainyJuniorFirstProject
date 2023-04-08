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

        Debug.Log("Макс" + maxObj);
        Debug.Log("Мин" + minObj);

        
        if (num <= maxObj && minObj <= num)
        {
            if (num == maxObj)
            {
                Debug.Log("меняем на зеленый");
                
            }
            else
            {
                Debug.Log("меняем на желтый");
                //FindObjectOfType<MaterialController>().ColorYellow();
            }
        }
        else
        {
            Debug.Log("меняем на красный");
            //FindObjectOfType<MaterialController>().ColorRed();
        }
    }

}
