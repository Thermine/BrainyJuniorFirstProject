
using System;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace djastas
{
    [RequireComponent(typeof(StopwatchComponent))]
    public class FakeSphere : MonoBehaviour
    {
        public UnityEvent action;
        public GameObject[] spheres;
        public GameObject target;
        public StopwatchComponent stopwatchComponent;
        
        private int _count;

        private void Start()
        {
            stopwatchComponent = GetComponent<StopwatchComponent>();
        }


        [ContextMenu("Explosion")]
        public void Explosion()
        {
            AudioManager.Instance.PlayAudioById("106");
            foreach (var i in spheres)
            {
                i.SetActive(true);
                i.GetComponent<DirectionForce>().AddForce();
            }
            stopwatchComponent.StartStopwatch();
            target.SetActive(false);
            action.Invoke();
            
        }

        public void MicroSphereExplosion()
        {
            _count++;
            if (!(_count >= spheres.Length)) return;
            stopwatchComponent.StopStopwatch();
        }
        
        
    }
}
