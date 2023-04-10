using UnityEngine;

namespace djastas
{
    public class DirectionForce : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float lengthGizmo;
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void AddForce()
        {
            _rb = GetComponent<Rigidbody>();
            Vector3 directionForce = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z) * Vector3.right;
            _rb.AddForce(directionForce * force);
       
        }

   
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 windDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector2.right;
            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + windDirection * lengthGizmo;
            Gizmos.DrawLine(startPos, endPos);
        }
    }
}