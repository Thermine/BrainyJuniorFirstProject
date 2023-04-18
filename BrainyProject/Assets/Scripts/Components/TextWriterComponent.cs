using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Component
{
    public class TextWriterComponent : MonoBehaviour
    {
        [SerializeField] private float waitBetweenCharts;
        [SerializeField] private TMP_Text text;
        [SerializeField] private string massage;
        [SerializeField] private bool loadTextOnAwake;
        [SerializeField] private string id;

        [SerializeField] private List<AudioClip> audioClips;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if(!loadTextOnAwake) return;
            massage = PlayerPrefs.GetString(id);

        }

        public void Start()
        {
            StartCoroutine(Writing());
        }

        IEnumerator Writing()
        {
            
            text.text = "";
            var t = "";
            foreach (var t1 in massage)
            {
                audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
                audioSource.Play();
                t += t1;
                text.text = t;
                yield return new WaitForSeconds(waitBetweenCharts);
            }
            
        }
        
        
    }
}
