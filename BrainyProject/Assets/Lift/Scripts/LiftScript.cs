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
    public Animator Lift_Animator;
    public bool IsStart;

    private void Start()
    {
        AsyncLoad = GetComponent<AsyncLoad>();
        if (IsStart)
        {
            StartCoroutine(StartLift());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            LevelAmbient.Stop();
            StartCoroutine(Lift());
            Lift_Animator.SetTrigger("Close");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
   
    IEnumerator Lift()
    {
        AudioManager.PlayAudioById(LiftAmbientID);
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
    }
    IEnumerator StartLift()
    {
        yield return new WaitForSeconds(2);
        Lift_Animator.SetTrigger("Open");
        LevelAmbient.Play();
        AudioManager.PlayAudioById("OpenDoor");

    }
}
