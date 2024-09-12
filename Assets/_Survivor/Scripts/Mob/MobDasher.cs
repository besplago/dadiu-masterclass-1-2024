using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class MobDasher : Mob
    {
        protected override void Start()
        {
            base.Start();
            
            CurrentState = new TelegraphingState();
        }
    }
}