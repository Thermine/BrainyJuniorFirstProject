using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveOfset : MonoBehaviour
{
    public Renderer materiial;
    public float speed = 1;
    float offset;
    // Update is called once per frame
    void FixedUpdate()
    {
         offset += Time.deltaTime * speed;
        materiial.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    } 
}
