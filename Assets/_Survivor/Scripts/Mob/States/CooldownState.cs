using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class CooldownState : IMobState
    {
        private const float CooldownTime = 3f;
        private float _elapsedTime = 0f;

        public void EnterState(Mob mob)
        {
            _elapsedTime = 0f;
        }

        public void UpdateState(Mob mob)
        {
            _elapsedTime += Time.deltaTime;

            if (!(_elapsedTime >= CooldownTime)) return;
            switch (mob)
            {
                case MobDasherShort:
                    mob.ChangeState(new ChaseAndStopState());
                    break;
                case MobDasherLong:
                    mob.ChangeState(new TelegraphingState());
                    break;
            }
        }

        public void ExitState(Mob mob)
        {
        }
    }
}