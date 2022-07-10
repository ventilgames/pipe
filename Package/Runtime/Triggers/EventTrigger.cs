using UnityEngine;
using UnityEngine.Events;

namespace VentilGames.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class EventTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collider> _triggerEnterHandlers;
        [SerializeField] private UnityEvent<Collider> _triggerStayHandlers;
        [SerializeField] private UnityEvent<Collider> _triggerExitHandlers;

        private void Start()
        {
            if (GetComponent<Collider>().isTrigger == false)
            {
                Debug.LogError("EventTrigger requires the Collider to be a trigger.");

                enabled = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _triggerEnterHandlers?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            _triggerStayHandlers?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _triggerExitHandlers?.Invoke(other);
        }
    }
}
