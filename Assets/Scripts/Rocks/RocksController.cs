using UnityEngine;

namespace Scripts.Stars 
{
    public class RocksController : MonoBehaviour
    {
        public float speed = 20.0f;

        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidBody.AddForce(Vector3.down * speed * Time.deltaTime, ForceMode.VelocityChange);
            if (transform.position.y < -10)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Rock"))
            {
                Destroy(gameObject);
            }
        }
    }
}