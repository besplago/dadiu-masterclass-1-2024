using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class RoamState : IMobState
    {
        private const float RoamTime = 5f;
        private const float RoamRadius = 10f;
        private float _elapsedTime;
        private Vector3 _targetPosition;
        private float _moveSpeed;

        public void EnterState(Mob mob)
        {
            _elapsedTime = 0f;
            SetNewRoamTarget(mob);
        }

        public void UpdateState(Mob mob)
        {
            _elapsedTime += Time.deltaTime;

            if (mob is not MobDasher dasher) return;
            MoveTowardsRoamTarget(dasher);

            if (_elapsedTime >= RoamTime)
            {
                dasher.ChangeState(new TelegraphingState());
            }

            if (Vector3.Distance(mob.transform.position, _targetPosition) <= 0.5f)
            {
                SetNewRoamTarget(mob);
            }
        }

        public void ExitState(Mob mob)
        {
        }

        private void SetNewRoamTarget(Mob mob)
        {
            var randomDirection = Random.insideUnitSphere * RoamRadius;
            randomDirection.y = 0f;
            _targetPosition = mob.transform.position + randomDirection;

            if (mob is MobDasher dasher)
            {
                _moveSpeed = dasher.Settings.roamSpeed;
            }
        }

        private void MoveTowardsRoamTarget(Mob mob)
        {
            var direction = (_targetPosition - mob.transform.position).normalized;
            mob.transform.position += direction * (_moveSpeed * Time.deltaTime);
        }
    }
}