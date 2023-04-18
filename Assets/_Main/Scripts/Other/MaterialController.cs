using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    public ButtonColor buttonColor;
    public float _info;

    private void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    public void OnMouseDown()
    {
        Infa();
        buttonColor.InfoScale(_info);
    }
    public void Infa()
    {
        _info = gameObject.transform.localScale.x * 10f;
    }

    public void ColorGreen()
    {
        rend.material = material[0];
    }

    public void ColorRed()
    {
        rend.material = material[1];
    }

    public void ColorYellow()
    {
        rend.material = material[2];
    }
}
