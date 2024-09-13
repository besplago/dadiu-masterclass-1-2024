using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class MobDasher : Mob
    {
        public Vector3 DashTargetPosition { get; set; }
        public AttackTelegraph AttackTelegraph { get; private set; }

        protected override void Start()
        {
            base.Start();

            DashTargetPosition = Target.transform.position;
            AttackTelegraph = GetComponentInChildren<AttackTelegraph>();
        }
    }
}