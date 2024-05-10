using UnityEngine;

namespace Assets.Scripts.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        public Vector3 lowHeight;
        public Vector3 highHeight;
        public float height;

        private void Start()
        {
            lowHeight = transform.position;
            highHeight = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(lowHeight, highHeight, Mathf.PingPong(Time.time, 1));
        }

    }
}
