using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform player;
        public float speed = 2.0f;
        public float distanceFromPlayer = 10.0f;
        public float staticCameraHeight = 0f;

        private void Start()
        {
            transform.position = new Vector3(player.position.x, staticCameraHeight, -distanceFromPlayer);
        }

        private void Update()
        {
            if (transform.position.y < player.position.y - 5)
                staticCameraHeight += 4f;
            else if (transform.position.y > player.position.y + 5)
                staticCameraHeight -= 4f;
            else staticCameraHeight = player.position.y;

            Vector3 target = new(player.position.x, staticCameraHeight, -distanceFromPlayer);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
