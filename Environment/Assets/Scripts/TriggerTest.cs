using UnityEngine;

using VentilGames.Triggers;

public class TriggerTest : MonoBehaviour
{
    [SerializeField] private DelegateTrigger _delegateTrigger;

    private void Start()
    {
        _delegateTrigger.TriggerEnterHandlers += OnDelegateTriggerEnter;
        _delegateTrigger.TriggerExitHandlers += OnDelegateTriggerExit;
    }

    private void OnDelegateTriggerEnter(Collider other)
    {
        Debug.Log("Delegate Enter");
    }

    private void OnDelegateTriggerExit(Collider other)
    {
        Debug.Log("Delegate Exit");
    }

    public void OnEventTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }

    public void OnEventTriggerExit(Collider other)
    {
        Debug.Log(other);
    }
}
