using djastas;
using System.Collections;
using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AsyncLoad))]
[RequireComponent(typeof(AudioSource))]
public class LiftScript : MonoBehaviour
{
    [SerializeField] private bool Dont_Close;
    [SerializeField] private UnityEvent exitLevelAction;
    [SerializeField] private AudioSource LevelAmbient;
    [SerializeField] private string LiftAmbientID;
    public Animator Lift_Animator;
    public AsyncLoad AsyncLoad;
    public int SceneIndex;
    AudioSource LastMeeting;

    private void Start()
    {
        LastMeeting = GetComponent<AudioSource>();
        AsyncLoad = GetComponent<AsyncLoad>();
        if (Dont_Close)
        {
            StartCoroutine(StartLift());
            LevelAmbient.Play();
        }
    }
    public void OpenLift()
    {
        StartCoroutine(StartLift());
    }
    public void CloseLift() 
    { 
            Dont_Close = true;
            Lift_Animator.speed = 1;
            LevelAmbient.Stop();
            Lift_Animator.SetTrigger("Close");
            exitLevelAction.Invoke();
            StartCoroutine(Lift());
    }
   
    IEnumerator Lift()
    {
        AudioManager.Instance.PlayAudioById(LiftAmbientID);
        yield return new WaitForSeconds(2);
        LastMeeting.Play();
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
        
    }
    [ContextMenu("Stest")]
    public IEnumerator StartLift()
    {

        yield return new WaitForSeconds(0.5f);
        Lift_Animator.SetTrigger("Open");
        AudioManager.Instance.PlayAudioById("OpenDoor");

    }
}
