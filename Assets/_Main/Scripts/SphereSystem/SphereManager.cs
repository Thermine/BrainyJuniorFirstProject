using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;

namespace djastas
{
    public class SphereManager : MonoBehaviour
    {

        [SerializeField] private SphereController[] sphereControllers;
        [SerializeField] private SphereController sphereController;
        
        public void SetSphereController(int i)
        {
            if (sphereController != null)
            {
                sphereController.gameObject.GetComponent<InteractObject>()?.EndInteract();
                CustomDebugConsole.Instance.Debug(sphereController.gameObject.name + " End Interact");
            }
            sphereController = sphereControllers[i];
            CustomDebugConsole.Instance.Debug(sphereController.gameObject.name + " Start Interact");
        }

        public void SetNumInSelectSphere(int value)
        {
            sphereController.SetNum(value);
        }

        public void SetNumInSelectSphere(string value)
        {
            SetNumInSelectSphere(int.Parse(value));
        }
    }
}
