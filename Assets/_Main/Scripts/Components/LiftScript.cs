using djastas;
using System.Collections;
using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;
using BrainyJunior.MyGame.Scripts.Audio;

[RequireComponent(typeof(AsyncLoad))]
public class LiftScript : MonoBehaviour
{
    [SerializeField] private bool Dont_Close;
    [SerializeField] private UnityEvent exitLevelAction;
 //   [SerializeField] private AudioSource LevelAmbient;
    [SerializeField] private string LiftAmbientID;
    [SerializeField] private AudioPlayer AudioPlayer;
    [SerializeField] private string LiftPlayerID;
    public Animator Lift_Animator;
    public AsyncLoad AsyncLoad;
    public int SceneIndex;
    
    private void Start()
    {
        AsyncLoad = GetComponent<AsyncLoad>();
        if (Dont_Close)
        {
            StartCoroutine(StartLift());
           // LevelAmbient.Play();
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
          //  LevelAmbient.Stop();
            Lift_Animator.SetTrigger("Close");
            exitLevelAction.Invoke();
            StartCoroutine(Lift());
    }
   
    IEnumerator Lift()
    {

        AudioPlayer.PlayAudioById(LiftAmbientID, true);
        if(LiftPlayerID != "")
        {
            AudioPlayer.PlayAudioById(LiftPlayerID);
        }
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
        
    }
    [ContextMenu("Stest")]
    public IEnumerator StartLift()
    {

        yield return new WaitForSeconds(0.5f);
        Lift_Animator.SetTrigger("Open");
        AudioPlayer.PlayAudioById("OpenDoor");


    }
}
