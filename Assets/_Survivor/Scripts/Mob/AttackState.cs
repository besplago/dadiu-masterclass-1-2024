using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackState : IMobState
    {
        private const float TargetProximityThreshold = 1f;
        private bool _accelerating = true;
        private float _dashSpeed;
        private MobDasherSettings _dasherSettings;

        public void EnterState(Mob mob)
        {
            _dasherSettings = mob.Settings as MobDasherSettings;
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
                _dashSpeed += _dasherSettings.attackAcceleration * Time.deltaTime;
                if (_dashSpeed >= _dasherSettings.attackMaxSpeed)
                {
                    _dashSpeed = _dasherSettings.attackMaxSpeed;
                    _accelerating = false;
                }
            }
            else
            {
                if (Vector3.Distance(mob.transform.position, mob.DashTarget) <= _dasherSettings.attackMaxSpeed * Time.deltaTime)
                {
                    _dashSpeed -= _dasherSettings.attackDeceleration * Time.deltaTime;
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