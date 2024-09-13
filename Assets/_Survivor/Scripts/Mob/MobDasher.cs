using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class MobDasher : Mob
    {
        public Vector3 DashTarget { get; set; }
        public AttackTelegraph AttackTelegraph { get; private set; }

        protected override void Start()
        {
            base.Start();

            DashTarget = Target.transform.position;
            AttackTelegraph = GetComponentInChildren<AttackTelegraph>();
        }
    }
}