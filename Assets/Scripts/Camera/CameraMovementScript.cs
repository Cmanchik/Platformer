using UnityEngine;

namespace Camera
{
    public class CameraMovementScript : MonoBehaviour
    {
        public Vector3 offset = new Vector3(0, 2);
        public float smooth = 5.0f;
        public Transform target;

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth);
        }
    }
}