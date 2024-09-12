using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackState : IMobState
    {
        public void EnterState(Mob mob)
        {
            mob.attackTelegraph.PlayAttackTelegraphAnimation(mob.Target.transform);
        }

        public void UpdateState(Mob mob)
        {
        }


        public void ExitState(Mob mob)
        {
        }
    }
}