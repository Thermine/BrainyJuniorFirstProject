using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace djastas
{
    public class InteractObject : MonoBehaviour
    {
        [FormerlySerializedAs("action")]
        
        [SerializeField] private UnityEvent interactAction;
        [SerializeField] private UnityEvent hoverAction;
        [SerializeField] private UnityEvent endHoverAction;
        public void Interact()
        {
            interactAction?.Invoke();
        }

        public void Hover()
        {
            hoverAction?.Invoke();

        }
        public void EndHover()
        {
            endHoverAction?.Invoke();

        }
    }
}
