using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackTelegraph : MonoBehaviour
    {
        public void PlayAttackTelegraphAnimation(Transform target)
        {
            var directionToTarget = target.position - transform.position;
            transform.position += directionToTarget * 0.5f;
            transform.LookAt(transform.position + directionToTarget);
            transform.localScale =
                new Vector3(transform.localScale.x, transform.localScale.y, directionToTarget.magnitude);
        }
    }
}