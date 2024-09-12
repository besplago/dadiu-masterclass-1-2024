using UnityEngine;
using System.Collections;

namespace _Survivor.Scripts.Mob
{
    public class AttackTelegraph : MonoBehaviour
    {
        private Renderer _telegraphRenderer;

        private void Awake()
        {
            _telegraphRenderer = GetComponent<Renderer>();
        }

        public void PlayAttackTelegraphAnimation(Mob mob)
        {
            _telegraphRenderer.enabled = true;
            SetTelegraphVisual(mob.Target.transform);
            StartCoroutine(BlinkAnimation(mob.Settings.attackTelegraphDuration));
        }

        private void SetTelegraphVisual(Transform target)
        {
            var directionToTarget = target.position - transform.position;
            transform.position += directionToTarget * 0.5f;
            transform.LookAt(transform.position + directionToTarget);
            transform.localScale =
                new Vector3(transform.localScale.x, transform.localScale.y, directionToTarget.magnitude);
        }

        private IEnumerator BlinkAnimation(float duration)
        {
            var halfDuration = duration / 2f;
            var time = 0f;

            var color = _telegraphRenderer.material.color;

            // Fade in
            while (time < halfDuration)
            {
                var alpha = Mathf.Lerp(0f, 1f, time / halfDuration);
                _telegraphRenderer.material.color = new Color(color.r, color.g, color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }

            _telegraphRenderer.material.color = new Color(color.r, color.g, color.b, 1f);

            time = 0f;
            // Fade out
            while (time < halfDuration)
            {
                var alpha = Mathf.Lerp(1f, 0f, time / halfDuration);
                _telegraphRenderer.material.color = new Color(color.r, color.g, color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }

            _telegraphRenderer.material.color = new Color(color.r, color.g, color.b, 0f);
            _telegraphRenderer.enabled = false;
        }
    }
}