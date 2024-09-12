using UnityEngine;

namespace _Survivor.Scripts
{
    public abstract class SpawnPoint : MonoBehaviour
    {
        protected virtual Color GizmoColor => Color.yellow;

        private void OnDrawGizmos()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawCube(transform.position + Vector3.up * 0.5f, Vector3.one);
        }
    }
}