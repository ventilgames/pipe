using System;

using UnityEngine;
using UnityEngine.Events;

namespace VentilGames.Logic
{
    public class Goal : MonoBehaviour
    {
        public int Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = Math.Max(Math.Min(value, _goalProgress), 0);

                _progressEvent?.Invoke(_progress);
                OnProgress?.Invoke(_progress);
            }
        }

        public delegate void ProgressEvent(int progress);
        public event ProgressEvent OnProgress;

        public delegate void GoalReachedEvent();
        public event GoalReachedEvent OnGoalReached;

        [SerializeField] private int _goalProgress = 100;

        [Space]

        [SerializeField] private UnityEvent<int> _progressEvent;
        [SerializeField] private UnityEvent _goalReachedEvent;

        private int _progress = 0;

        private void Start()
        {
            OnProgress += OnProgressChanged;
        }

        private void OnDisable()
        {
            OnProgress -= OnProgressChanged;
        }

        private void OnProgressChanged(int progress)
        {
            if (progress >= _goalProgress)
            {
                _goalReachedEvent?.Invoke();
                OnGoalReached?.Invoke();

                enabled = false;
            }
        }
    }
}
