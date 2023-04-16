using djastas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiftScript : MonoBehaviour
{

    public AsyncLoad AsyncLoad;
    public int SceneIndex;
    public AudioManager AudioManager;
    public AudioSource LevelAmbient;
    public string LiftAmbientID;
    public Animator Lift_Animator;
    public bool IsStart;

    [SerializeField] private UnityEvent exitLevelAction;

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
        if(other.gameObject.tag == "Player" && !IsStart)
        {
            Lift_Animator.speed = 1;
            LevelAmbient.Stop();
            StartCoroutine(Lift());
            Lift_Animator.SetTrigger("Close");
            GetComponent<BoxCollider>().enabled = false;
            exitLevelAction.Invoke();
        }
    }
   
    IEnumerator Lift()
    {
        AudioManager.PlayAudioById(LiftAmbientID);
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
    }
    [ContextMenu("Stest")]
    public IEnumerator StartLift()
    {

        yield return new WaitForSeconds(0.5f);
        Lift_Animator.SetTrigger("Open");
        LevelAmbient.Play();
        AudioManager.PlayAudioById("OpenDoor");

    }
}
