using BrainyJunior.MyGame.Scripts.Audio;
using BrainyJunior.MyGame.Scripts.Managers;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

namespace djastas.Scripts
{
    [RequireComponent(typeof(AudioPlayer))]
    public class Laser : MonoBehaviour
    {
        [SerializeField] private HVRPlayerController playerController;
        [SerializeField] private GameObject particle;
        [SerializeField] private float lengthGizmo;
        [SerializeField] private float reloadTime;

        private AudioPlayer _audioPlayer;
        private float _remainingTime;
        private InteractObject _lastHoverCall;

        private void Start()
        {
            _audioPlayer = GetComponent<AudioPlayer>();
        }

        private void Update()
        {
            if (playerController.RightHand.Inputs.IsRightTriggerHoldActive) // input 
            {
                // recharge check
                if ( _remainingTime <= 0) 
                {
                    _remainingTime += reloadTime;
                    Shoot();
                }
                else
                {
                    _remainingTime -= Time.deltaTime;
                }
            }
            else
            {
                HoverShoot(); 
            }
        }
        
        [ContextMenu("TestShoot")]
        public void Shoot()
        {
            _audioPlayer.PlayAudioById("shoot"); // audio
            
            Instantiate(particle,gameObject.transform); // spawn particle
            
            RaycastHit hit; // raycast
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    Mathf.Infinity)) return;
            
            var i = hit.collider.gameObject.GetComponent<InteractObject>(); // find  InteractObject in target
            if (i== null)
            {
                i = hit.transform.gameObject.GetComponentInParent<InteractObject>(); // find InteractObject in target parent
            }
                
            if (i!=null)
            {
                i.Interact();
            }
            else
            {
                Debug.Log("object not interactable");
                CustomDebugConsole.Instance.Debug("object not interactable"); // debug in play mode in vr
            }

        }
        public void HoverShoot()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, Mathf.Infinity))
            {
                var interact = hit.transform.gameObject.GetComponent<InteractObject>(); // find  InteractObject in target
                if (interact == null)
                {
                    interact = hit.transform.gameObject.GetComponentInParent<InteractObject>(); // find InteractObject in target parent
                }

                if (_lastHoverCall != null && _lastHoverCall != interact) // if you are focused on another object or null
                {
                    _lastHoverCall.EndHover();
                    _lastHoverCall = null;
                }

                if (interact == null) return; 

                interact.Hover(); 
                
                _lastHoverCall = interact;
            }
            else
            {
                if (_lastHoverCall == null) return;
                _lastHoverCall.EndHover();
                _lastHoverCall = null;
            }
        }
        
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 windDirection = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * Vector3.forward;
            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + windDirection * lengthGizmo;
            Gizmos.DrawLine(startPos, endPos);
        }
    }
}
