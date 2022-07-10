using System.Collections;

using UnityEngine;
using UnityEngine.Events;

namespace VentilGames.Logic
{
    public class DelayRelay : MonoBehaviour
    {
        [SerializeField]
        private float _delay = 1.0f;

        [SerializeField]
        private UnityEvent _onFire;

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(_delay);

            _onFire?.Invoke();
        }

        public void Run()
        {
            StartCoroutine(Delay());
        }
    }
}
