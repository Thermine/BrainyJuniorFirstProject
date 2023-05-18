using BrainyJunior.MyGame.Scripts.Audio;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace djastas
{
    [RequireComponent(typeof(StopwatchComponent))]
    [RequireComponent(typeof(AudioPlayer))]
    public class FakeSphere : MonoBehaviour
    {
        public UnityEvent action;
        public GameObject[] spheres;
        public GameObject target;
        
        [HideInInspector] public StopwatchComponent stopwatchComponent;
        [HideInInspector] public AudioPlayer audioPlayer;
        
        private int _count;

        private void Start()
        {
            stopwatchComponent = GetComponent<StopwatchComponent>();
        }


        [ContextMenu("Explosion")]
        public void Explosion()
        {
            BackgroundMusicManager.Instance.PlayAudioById("106"); // play voice 
            audioPlayer.PlayAudioById("304"); // play audio
            foreach (var i in spheres)
            {
                i.SetActive(true);
                i.GetComponent<DirectionForce>()?.AddForce(); // add force to mini sphere
            }

            stopwatchComponent.StartStopwatch();
            target.SetActive(false); // hiding visual
            action.Invoke();
            
        }

        public void MicroSphereExplosion()
        {
            var i = Random.Range(111, 115); // get random audio voice
            audioPlayer.PlayAudioById(i.ToString()); // play audio

            _count++;
            if (!(_count >= spheres.Length)) return; 
            stopwatchComponent.StopStopwatch();
        }
        
        
    }
}
