using UnityEngine;

namespace _Survivor.Scripts
{
    public class ChaseState : IMobState
    {
        public void EnterState(Mob mob)
        {
        }

        public void UpdateState(Mob mob)
        {
            if (!mob.Target) return;

            var delta = mob.Target.transform.position - mob.transform.position;
            if (delta.magnitude <= 0) return;

            var motion = delta.normalized * (Time.deltaTime * mob.Settings.MoveSpeed);
            mob.Controller.Move(motion);
        }

        public void ExitState(Mob mob)
        {
        }
    }

    namespace _Survivor.Scripts
    {
        public class AttackState : IMobState
        {
            public void EnterState(Mob mob)
            {
            }

            public void UpdateState(Mob mob)
            {
            }


            public void ExitState(Mob mob)
            {
            }
        }
    }
}