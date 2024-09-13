using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class RoamState : IMobState
    {
        private const float RoamTime = 5f;
        private const float RoamRadius = 10f;
        private float _elapsedTime = 0f;
        private Vector3 _targetPosition;
        private float _moveSpeed;
        private MobDasherSettings _dasherSettings;

        public void EnterState(Mob mob)
        {
            _dasherSettings = mob.Settings as MobDasherSettings;
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
                _moveSpeed = _dasherSettings.roamSpeed; // TODO: Dasher Settings should come from the MobDasher class 
            }
        }

        private void MoveTowardsRoamTarget(Mob mob)
        {
            Vector3 direction = (_targetPosition - mob.transform.position).normalized;
            mob.transform.position += direction * (_moveSpeed * Time.deltaTime);
        }
    }
}