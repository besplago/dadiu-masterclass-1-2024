using UnityEngine;
using System.Collections;

namespace _Survivor.Scripts.Mob
{
    public class AttackTelegraph : MonoBehaviour
    {
        private Renderer _telegraphRenderer;
        private Transform _parentTransform;

        private void Awake()
        {
            _telegraphRenderer = GetComponent<Renderer>();
            _parentTransform = transform.parent;
        }

        public void PlayAttackTelegraphAnimation(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            _telegraphRenderer.enabled = true;
            SetTelegraphVisual(mob);
            StartCoroutine(BlinkAnimation(dasher.Settings.dashTelegraphDuration));
        }

        private void SetTelegraphVisual(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            var startPosition = _parentTransform.position;
            var endPosition = dasher.DashTargetPosition;
            var midPointPosition = (startPosition + endPosition) / 2f;
            transform.position = midPointPosition;
            
            var distance = Vector3.Distance(startPosition, endPosition);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, distance);
            
            var direction = (startPosition - endPosition).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
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