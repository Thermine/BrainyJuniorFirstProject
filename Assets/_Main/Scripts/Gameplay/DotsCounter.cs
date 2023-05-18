using BrainyJunior.MyGame.Scripts.Managers;
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
            StartCoroutine(play2Sounds());

        }
    }
    IEnumerator play2Sounds()
    {
        BackgroundMusicManager.Instance.PlayAudioById("107");
        yield return new WaitForSeconds(3);
        BackgroundMusicManager.Instance.PlayAudioById("108");
    }
}
