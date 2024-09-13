using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class MobDasher : Mob
    {
        public Vector3 DashTargetPosition { get; set; }
        public DashTelegraph DashTelegraph { get; private set; }

        public new MobDasherSettings Settings => (MobDasherSettings)base.Settings;

        protected override void Start()
        {
            base.Start();

            DashTargetPosition = Target.transform.position;
            DashTelegraph = GetComponentInChildren<DashTelegraph>();
        }
    }
}