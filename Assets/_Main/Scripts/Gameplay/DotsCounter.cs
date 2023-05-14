using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsCounter : MonoBehaviour
{
    [SerializeField] private LiftScript LiftScript;
    private int DotsLeft = 10;

    public void OnDetroyDot()
    {
        DotsLeft--;
        if(DotsLeft == 0)
        {
            LiftScript.OpenLift();
        }
    }
}
