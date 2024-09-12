using UnityEngine;
using System.Collections;

namespace _Survivor.Scripts.Mob
{
    public class AttackTelegraph : MonoBehaviour
    {
        private Renderer _telegraphRenderer;
        private Transform _parentTransform;
        private const float ExtraTelegraphLength = 3.0f;
        private MobDasherSettings _dasherSettings;

        private void Awake()
        {
            _telegraphRenderer = GetComponent<Renderer>();
            _parentTransform = transform.parent;
        }

        public void PlayAttackTelegraphAnimation(Mob mob)
        {
            _telegraphRenderer.enabled = true;
            SetTelegraphVisual(mob);
            _dasherSettings = mob.Settings as MobDasherSettings;
            if (_dasherSettings) StartCoroutine(BlinkAnimation(_dasherSettings.attackTelegraphDuration));
        }

        private void SetTelegraphVisual(Mob mob)
        {
            transform.position = _parentTransform.position;
            var directionToTarget = mob.Target.transform.position - transform.position;
            transform.position += directionToTarget * (0.5f + ExtraTelegraphLength / 10.0f);
            if (!_dasherSettings) return;
            var newMagnitude = directionToTarget.magnitude + _dasherSettings.extraTelegraphLength;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newMagnitude);
            transform.LookAt(transform.position +
                             directionToTarget.normalized * (newMagnitude - directionToTarget.magnitude));
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