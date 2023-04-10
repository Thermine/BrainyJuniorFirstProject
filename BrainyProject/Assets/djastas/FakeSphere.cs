
using UnityEngine;

namespace djastas
{
    public class FakeSphere : MonoBehaviour
    {
        public GameObject[] spheres;
        public GameObject target;
        
        [ContextMenu("Explosion")]
        public void Explosion()
        {
            foreach (var i in spheres)
            {
                i.SetActive(true);
                i.GetComponent<DirectionForce>().AddForce();
            }
            target.SetActive(false);
        }
    }
}
