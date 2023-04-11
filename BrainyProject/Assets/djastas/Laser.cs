using UnityEngine;

namespace djastas
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float lengthGizmo;
        [SerializeField] private GameObject particle;
        [ContextMenu("er")]
        public void Shoot()
        {
            
            RaycastHit hit;
            Instantiate(particle,gameObject.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                var i = hit.collider.gameObject.GetComponent<InteractObject>();
                i?.Interact();
                Debug.Log("Did Hit");
            }
            else
            {
              
                Debug.Log("Did not Hit");
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
