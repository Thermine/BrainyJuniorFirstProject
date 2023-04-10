using djastas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{

    AsyncLoad AsyncLoad;
    public int SceneIndex;
    public AudioManager AudioManager;
    public AudioSource LevelAmbient;
    public string LiftAmbientID;
    Animator Lift_Animator;

    private void Start()
    {
        AsyncLoad = GetComponent<AsyncLoad>();
        Lift_Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            LevelAmbient.Stop();
            StartCoroutine(Lift());
          //  Lift_Animator.SetTrigger("Close");
        }
    }
   
    IEnumerator Lift()
    {
        AudioManager.PlayAudioById(LiftAmbientID);
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
    }
}
