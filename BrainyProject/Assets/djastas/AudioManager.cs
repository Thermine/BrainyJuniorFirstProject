using System;
using System.Collections.Generic;
using UnityEngine;

namespace djastas
{
    public class AudioManager : MonoBehaviour {
        
        [SerializeField] private List<AudioObject> audioList; // лист с звуками
        
        private AudioSource _audioSource;
        
        
        void Start() {
            _audioSource = GetComponent<AudioSource>();
        }
        
        // функция проигрывает звук в соответстие с id
        public void PlayAudioById(string id) 
        {
            
            AudioObject audioObj = audioList.Find(obj => obj.id == id);

            if (audioObj != null) {
                _audioSource.clip = audioObj.audio;
                _audioSource.Play();
            }
            else
            {
                Debug.LogWarning("неправильно указано название трека");
            }
        }
    
        [Serializable]
        public class AudioObject {
            public string id;
            public AudioClip audio;
        }
    }
}