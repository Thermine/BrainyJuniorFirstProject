using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;

namespace BrainyJunior.MyGame.Scripts.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private List<BackgroundMusicManager.AudioObject> audioList;
        [SerializeField] private GameObject audioSourcePrefab;
        private List<AudioSource> _audioSources;

        private void Start()
        {
            _audioSources = new List<AudioSource>();
        }
        
        public int PlayAudioById(string id, bool loop = false , bool isBackground = false)
        {
            BackgroundMusicManager.AudioObject audioObj;
            audioObj = audioList.Find(obj => obj.id == id);
            if (audioObj != null)
            {
                return PlayAudioObject(audioObj, loop);
            }
            Debug.LogWarning("name of the audio track incorrect");
            return 0;
        }

        public void PlayAudioByIdToUnityEvent(string id) // method use unity events to call PlayAudioById 
        {
           PlayAudioById(id);
        }
        public int PlayAudioObject(BackgroundMusicManager.AudioObject audioObject, bool loop = false)
        {
            var audioSource = Instantiate(audioSourcePrefab,gameObject.transform);
              
            _audioSources.Add(audioSource.GetComponent<AudioSource>());
            _audioSources[^1].gameObject.name = audioObject.id;
            _audioSources[^1].loop = loop;
            _audioSources[^1].clip = audioObject.audio;
            _audioSources[^1].Play();
              
            return _audioSources.Count - 1;
        }
        public void DeleteAudioNum(int num)
        {
            Destroy(_audioSources[num].gameObject);
        }
        public void StopAudioNum(int num)
        {
            _audioSources[num].Stop();
        }
          
        public void PlayAudioNum(int num)
        {
            _audioSources[num].Play();
        }
        
        
    }
}

