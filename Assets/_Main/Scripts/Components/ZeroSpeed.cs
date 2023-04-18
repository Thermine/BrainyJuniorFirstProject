using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroSpeed : MonoBehaviour
{
    private Animator Animator;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void StopSpeed()
    {
        Animator.speed = 0;
    }
}
