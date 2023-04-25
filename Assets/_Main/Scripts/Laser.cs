using HurricaneVR.Framework.Core.Player;
using UnityEngine;

namespace djastas.Scripts
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float lengthGizmo;
        [SerializeField] private GameObject particle;
        [SerializeField] private HVRPlayerController pc;
        [SerializeField] private float reloadTime;

        private float _remainingTime;
        private InteractObject _lastHoverCall;
        private void Update()
        {
            if (pc.RightHand.Inputs.IsRightTriggerHoldActive)
            {
                if ( _remainingTime <= 0)
                {
                    _remainingTime += reloadTime;
                    Shoot();
                }
                else
                {
                    HoverShoot();
                    _remainingTime -= Time.deltaTime;
                }
            }
           

        }
        [ContextMenu("TestShoot")]
        public void Shoot()
        {
            
            RaycastHit hit;
            Instantiate(particle,gameObject.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                var i = hit.collider.gameObject.GetComponent<InteractObject>();
                if (i== null)
                {
                    i = hit.transform.gameObject.GetComponentInParent<InteractObject>();
                }
                if (i!=null)
                {
                    i.Interact();
                }else
                {
                    Debug.Log("object not interactable");
                }

                Debug.Log("Did Hit");
            }
            else
            {
              
                Debug.Log("Did not Hit");
            }
        }
        public void HoverShoot()
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, Mathf.Infinity))
            {
                var interact = hit.transform.gameObject.GetComponent<InteractObject>();
                if (interact == null)
                {
                    interact = hit.transform.gameObject.GetComponentInParent<InteractObject>();
                }

                if (_lastHoverCall != null && _lastHoverCall != interact)
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
                if (_lastHoverCall != null)
                {
                    _lastHoverCall.EndHover();
                    _lastHoverCall = null;
                }
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
