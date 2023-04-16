using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace djastas
{
    public class InputFieldController : MonoBehaviour
    {
        [SerializeField] private Action action;
        [SerializeField] private InputField inputField;

        public void Submit()
        {
            
        action?.Invoke(inputField.text);
        }
[Serializable]
        private class  Action : UnityEvent<string>
        {
            
        }

    }
}
