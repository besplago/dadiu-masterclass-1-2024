using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMotor : MonoBehaviour
    {
        [FormerlySerializedAs("_config")] [SerializeField] HeroMotorSettings config;

        private CharacterController _controller;

        private Vector3 _velocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Update()
        {

            Vector2 input = new() { x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical")};


            Vector3 moveDirection = Vector3.right * input.x + Vector3.forward * input.y;

            var right = Vector3.right;
            var forward = Vector3.forward;

            var velocityOnRight = Vector3.Dot(_velocity, right);
            var velocityOnForward = Vector3.Dot(_velocity, forward);
        

            var velocity = Mathf.MoveTowards(velocityOnRight, input.x, config.Accelleration * Time.deltaTime);


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
