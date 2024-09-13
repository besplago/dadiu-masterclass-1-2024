using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class DashState : IMobState
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
            if (mob is not MobDasher dasher) return;
            DashMovement(dasher);

            if (Vector3.Distance(dasher.transform.position, dasher.DashTargetPosition) <= TargetProximityThreshold)
            {
                switch (dasher)
                {
                    case MobDasherShort:
                        dasher.ChangeState(new CooldownState());
                        break;
                    case MobDasherLong:
                        dasher.ChangeState(new RoamState());
                        break;
                }
            }
        }

        public void ExitState(Mob mob)
        {
        }

        private void DashMovement(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            var direction = (dasher.DashTargetPosition - dasher.transform.position).normalized;

            if (_accelerating)
            {
                _dashSpeed += dasher.Settings.dashAcceleration * Time.deltaTime;
                if (_dashSpeed >= dasher.Settings.dashMaxSpeed)
                {
                    _dashSpeed = dasher.Settings.dashMaxSpeed;
                    _accelerating = false;
                }
            }
            else
            {
                if (Vector3.Distance(dasher.transform.position, dasher.DashTargetPosition) <= dasher.Settings.dashMaxSpeed * Time.deltaTime)
                {
                    _dashSpeed -= dasher.Settings.dashDeceleration * Time.deltaTime;
                    if (_dashSpeed <= 0f)
                    {
                        _dashSpeed = 0f;
                    }
                }
            }

            dasher.transform.position += direction * (_dashSpeed * Time.deltaTime);
        }
    }
}