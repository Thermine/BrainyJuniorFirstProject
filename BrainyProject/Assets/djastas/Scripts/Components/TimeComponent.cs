using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Pixelcrew.component
{
    public class TimeComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;
        [SerializeField] private float time;
        [SerializeField] private bool startTimerOnStart;


        private void Start()
        {
            if (startTimerOnStart)
            {
                StartCoroutine(Time());
            }
        }


        public void StartTimer()
        {
            StartCoroutine(Time());
        }
        IEnumerator Time()
        {
          
            yield return new WaitForSeconds(time);
            _action?.Invoke();
            
        }
        
        
    }
}