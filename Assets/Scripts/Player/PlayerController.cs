using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float Acceleration = 15.0f;
        public float Speed = 1.0f;
        public float JumpForce = 185.0f;

        private Rigidbody _rigidBody;
        [SerializeField] private Animator _animator;
        private float _horizontalInput;
        private float _velocity;
        [SerializeField] private bool _isJumping;
        [SerializeField] private bool _isRunning;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            if (_horizontalInput != 0f)
            {
                _velocity = Mathf.Clamp(_velocity + _horizontalInput * Acceleration * Time.deltaTime, -1f, 1f);
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _velocity -= _velocity * Acceleration * Time.deltaTime;
                _animator.SetBool("isWalking", false);
            }
            
            if (Input.GetKey(KeyCode.LeftShift) && !_isRunning && !_isJumping)
            {
                _isRunning = true;
                Speed *= 2;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && _isRunning)
            {
                _isRunning = false;
                Speed /= 2;
            }

            if (Input.GetKey(KeyCode.Space) && !_isJumping)
            {
                _rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                _isJumping = true;
            }
        }

        private void FixedUpdate()
        {
            _rigidBody.velocity = new Vector3((Mathf.Abs(_velocity) < .01f ? .0f : _velocity) * Speed, _rigidBody.velocity.y, 0f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Rock")) _animator.SetBool("takeDamage", true);
            else _animator.SetBool("takeDamage", false);
            _isJumping = false;
        }
    }
}
