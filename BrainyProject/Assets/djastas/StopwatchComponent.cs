using System;
using UnityEngine;

namespace djastas
{
    public class StopwatchComponent : MonoBehaviour
    {
        public float time;
        [SerializeField] private bool stopwatchIsStart;

        private void Update()
        {
            if (!stopwatchIsStart) return;
            time += Time.deltaTime;
        }

        public void StartStopwatch()
        {
            stopwatchIsStart = true;
        }
        public void StopStopwatch()
        {
            stopwatchIsStart = false;
        }

        public float GetTime()
        {
            return time;
        }

        public void ClearStopwatch()
        {
            time = 0;
        }
    }
}
