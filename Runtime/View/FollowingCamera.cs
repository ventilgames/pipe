using UnityEngine;

namespace VentilGames.View
{
    public class FollowingCamera : MonoBehaviour
    {
        public Transform Target { get; set; }

        [SerializeField, Tooltip("Automatically calculate starting offset")] private bool _autoOffset = false;

        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _positionOffset;

        private void Start()
        {
            if (_autoOffset == true && Target != null)
            {
                _positionOffset = transform.position - Target.transform.position;
            }
        }

        private void Update()
        {
            if (Target != null)
            {
                Vector3 targetNormalized = Target.position + _positionOffset;

                transform.position = Vector3.Lerp(transform.position, targetNormalized, _speed * Time.deltaTime);
            }
        }
    }
}
