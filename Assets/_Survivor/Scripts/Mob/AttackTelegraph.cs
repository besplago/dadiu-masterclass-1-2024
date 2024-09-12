using UnityEngine;

// NOTE: I tried to implement the telegraphing logic all in here instead of having it referenced in the Mob class and
// doing the logic there to keep it contained and modular, so for example I now have to find the target (hero) in here
// as well. Thoughts?
namespace _Survivor.Scripts.Mob
{
    public class AttackTelegraph : MonoBehaviour
    {
        private void OnEnable()
        {
            Mob.OnStateChanged += HandleOnStateChanged;
        }

        private void OnDisable()
        {
            Mob.OnStateChanged -= HandleOnStateChanged;
        }

        private static void HandleOnStateChanged(IMobState state)
        {
            switch (state)
            {
                case AttackState:
                    PlayAttackTelegraphAnimation();
                    break;
            }
        }

        private static void PlayAttackTelegraphAnimation()
        {
            Debug.Log("Telegraphing!");
        }
    }
}