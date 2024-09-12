using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class AttackState : IMobState
    {
        public void EnterState(Mob mob)
        {
            Debug.Log(this + " is within range of the player, it will now attack!");
        }

        public void UpdateState(Mob mob)
        {
        }


        public void ExitState(Mob mob)
        {
        }
    }
}