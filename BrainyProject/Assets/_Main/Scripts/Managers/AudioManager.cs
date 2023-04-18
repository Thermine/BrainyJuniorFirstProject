  using System;
  using System.Collections.Generic;
  using StvDEV.StarterPack;
  using UnityEngine;
 
  namespace BrainyJunior.MyGame.Scripts.Singleton
  {
      public class AudioManager : MonoBehaviourSingleton<AudioManager> {
          
          [SerializeField] private List<AudioObject> audioList;
          
          private AudioSource _audioSource;
          
          
          void Start() {
              _audioSource = GetComponent<AudioSource>();
          }
          
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

