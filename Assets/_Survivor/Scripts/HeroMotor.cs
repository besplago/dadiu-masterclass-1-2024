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

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            Vector2 input = new() { x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical") };

            var moveDirection = Vector3.right * input.x + Vector3.forward * input.y;

            var right = Vector3.right;
            var forward = Vector3.forward;

            Vector3.Dot(_velocity, right);
            Vector3.Dot(_velocity, forward);

            moveDirection.Normalize();

            _controller.Move(moveDirection * (config.MaxSpeed * Time.deltaTime));
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