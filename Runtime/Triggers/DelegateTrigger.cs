using UnityEngine;

namespace VentilGames.Triggers
{
    [RequireComponent(typeof(Collider))]
    public class DelegateTrigger : MonoBehaviour
    {
        public delegate void TriggerEventHandler(Collider other);

        [HideInInspector] public TriggerEventHandler TriggerEnterHandlers;
        [HideInInspector] public TriggerEventHandler TriggerStayHandlers;
        [HideInInspector] public TriggerEventHandler TriggerExitHandlers;

        private void Start()
        {
            if(GetComponent<Collider>().isTrigger == false)
            {
                Debug.LogError("DelegateTrigger requires the Collider to be a trigger.");

                enabled = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnterHandlers?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerStayHandlers?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExitHandlers?.Invoke(other);
        }
    }
}
