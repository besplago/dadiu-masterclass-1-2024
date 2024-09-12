using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackState : IMobState
    {
        public void EnterState(Mob mob)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState(Mob mob)
        {
            mob.ChangeState(new CooldownState());
        }

        public void ExitState(Mob mob)
        {
            throw new System.NotImplementedException();
        }
    }
}