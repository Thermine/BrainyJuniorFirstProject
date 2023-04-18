using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    public InputField _number;
    int _numb;
    float _objectScale;

    private ChangeColor change;
    

    private void Start()
    {
        change = GetComponent<ChangeColor>();
    }

    public void InfoScale(float scale)
    {
        _objectScale = scale;
        Debug.Log("Инфа есть " + _objectScale);
    }

    public void collorBut()
    {
        _numb = int.Parse(_number.text);
        change.ScaleObject(_numb, _objectScale);
    }
    
}
