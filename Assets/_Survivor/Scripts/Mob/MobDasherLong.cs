using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class MobDasherLong : Mob
    {
        protected override void Start()
        {
            base.Start();
            
            CurrentState = new TelegraphingState();
        }
    }
}