using UnityEngine;
using UnityEngine.Events;

namespace djastas
{
    public class InteractObject : MonoBehaviour
    {

        [SerializeField] private UnityEvent action;
        public void Interact()
        {
            action?.Invoke();
        }
    }
}
