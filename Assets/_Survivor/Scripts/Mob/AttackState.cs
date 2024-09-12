using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackState : IMobState
    {
        private const float TargetProximityThreshold = 1f;
        private bool _accelerating = true;
        private float _dashSpeed;

        public void EnterState(Mob mob)
        {
            _dashSpeed = 0f;
            _accelerating = true;
        }

        public void UpdateState(Mob mob)
        {
            DashMovement(mob);

            if (Vector3.Distance(mob.transform.position, mob.DashTarget) <= TargetProximityThreshold)
            {
                mob.ChangeState(new CooldownState());
            }
        }

        public void ExitState(Mob mob)
        {
        }

        private void DashMovement(Mob mob)
        {
            var direction = (mob.DashTarget - mob.transform.position).normalized;

            if (_accelerating)
            {
                _dashSpeed += mob.Settings.attackAcceleration * Time.deltaTime;
                if (_dashSpeed >= mob.Settings.attackMaxSpeed)
                {
                    _dashSpeed = mob.Settings.attackMaxSpeed;
                    _accelerating = false;
                }
            }
            else
            {
                if (Vector3.Distance(mob.transform.position, mob.DashTarget) <= mob.Settings.attackMaxSpeed * Time.deltaTime)
                {
                    _dashSpeed -= mob.Settings.attackDeceleration * Time.deltaTime;
                    if (_dashSpeed <= 0f)
                    {
                        _dashSpeed = 0f;
                    }
                }
            }

            mob.transform.position += direction * (_dashSpeed * Time.deltaTime);
        }
    }
}