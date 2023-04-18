using UnityEngine;
using UnityEngine.UI;

namespace djastas
{
    public class SphereManager : MonoBehaviour
    {
        [SerializeField] private Text DEBUG;
        [SerializeField] private SphereController[] sphereControllers;
        [SerializeField] private SphereController sphereController;
    

        public void SetSphereController(int i)
        {
            DEBUG.text = i.ToString();
            sphereController = sphereControllers[i];
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
