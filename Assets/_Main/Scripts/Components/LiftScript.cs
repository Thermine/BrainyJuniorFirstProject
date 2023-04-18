using djastas;
using System.Collections;
using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Singleton;
using UnityEngine;
using UnityEngine.Events;

public class LiftScript : MonoBehaviour
{

    public AsyncLoad AsyncLoad;
    public int SceneIndex;
    public AudioSource LevelAmbient;
    public string LiftAmbientID;
    public Animator Lift_Animator;
    public bool Dont_Close;

    [SerializeField] private UnityEvent exitLevelAction;

    private void Start()
    {
        AsyncLoad = GetComponent<AsyncLoad>();
        if (Dont_Close)
        {
            StartCoroutine(StartLift());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !Dont_Close)
        {
            Dont_Close = true;
            Lift_Animator.speed = 1;
            LevelAmbient.Stop();
            Destroy(GetComponent<BoxCollider>());
            exitLevelAction.Invoke();
            Lift_Animator.SetTrigger("Close");
            StartCoroutine(Lift());
        }
    }
   
    IEnumerator Lift()
    {
        AudioManager.Instance.PlayAudioById(LiftAmbientID);
        yield return new WaitForSeconds(10);
        AsyncLoad.AsyncLoading(SceneIndex);
    }
    [ContextMenu("Stest")]
    public IEnumerator StartLift()
    {

        yield return new WaitForSeconds(0.5f);
        Lift_Animator.SetTrigger("Open");
        LevelAmbient.Play();
        AudioManager.Instance.PlayAudioById("OpenDoor");

    }
}
