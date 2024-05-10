using UnityEngine;

namespace Assets.Scripts.Player
{
    public class DeathController : MonoBehaviour
    {
        public Transform respawnPoint;

        private void Update()
        {
            if (transform.position.y < -10)
            {
                transform.position = respawnPoint.position;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Spike"))
            {
                transform.position = respawnPoint.position;
            }
        }
    }
}
