using UnityEngine;

namespace VentilGames.Logic
{
    public class SubGoal : MonoBehaviour
    {
        [SerializeField] private Goal _mainGoal;

        [Space]

        [SerializeField] private int _progressGain = 50;
        [SerializeField] private bool _disableOnAchievement = true;

        public void Achieve()
        {
            _mainGoal.Progress += _progressGain;

            if (_disableOnAchievement)
            {
                enabled = false;
            }
        }
    }
}
