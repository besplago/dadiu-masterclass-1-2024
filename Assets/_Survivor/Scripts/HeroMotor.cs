using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMotor : MonoBehaviour
    {
        [FormerlySerializedAs("_config")] [SerializeField]
        private HeroMotorSettings config;

        private CharacterController _controller;
        private Vector3 _velocity;

        private bool _isDashing;
        private float _lastDashTime = -1f;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            Vector2 input = new() { x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical") };

            var moveDirection = Vector3.right * input.x + Vector3.forward * input.y;
            moveDirection.Normalize();

            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > _lastDashTime + config.dashCooldown)
            {
                _isDashing = true;
                _lastDashTime = Time.time;
            }

            if (_isDashing)
            {
                _controller.Move(moveDirection * (config.maxSpeed * config.dashSpeedMultiplier * Time.deltaTime));

                if (Time.time >= _lastDashTime + config.dashTime)
                {
                    _isDashing = false;
                }
            }
            else
            {
                _controller.Move(moveDirection * (config.maxSpeed * Time.deltaTime));
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            _velocity -= Vector3.Project(_velocity, hit.normal);
        }

        public void Teleport(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}