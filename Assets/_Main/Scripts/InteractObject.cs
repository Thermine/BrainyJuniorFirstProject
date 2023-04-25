using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace djastas
{
    public class InteractObject : MonoBehaviour
    {
        [FormerlySerializedAs("action")]
        
        [SerializeField] private UnityEvent interactAction;
        [SerializeField] private UnityEvent endInteractAction;
        [SerializeField] private UnityEvent hoverAction;
        [SerializeField] private UnityEvent endHoverAction;

        private bool _isInteract;
        public void Interact()
        {
            _isInteract = true;
            interactAction?.Invoke();
        }

        public void EndInteract()
        {
            _isInteract = false;
            endInteractAction?.Invoke();
        }

        public void Hover()
        {
            if (_isInteract) return;
            
            hoverAction?.Invoke();
        }
        public void EndHover()
        {
            if (_isInteract) return;
            
            endHoverAction?.Invoke();
        }
    }
}
