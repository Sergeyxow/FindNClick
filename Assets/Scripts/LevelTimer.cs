using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class LevelTimer : ITickable
    {
        public Action<float> TimeUpdated;
        public Action<int> SecondsUpdated;

        private float _time;
        private int _seconds;
        
        public void Tick()
        {
            _time += Time.deltaTime;

            int seconds = Mathf.FloorToInt(_time);
            
            if (seconds > _seconds)
            {
                _seconds = seconds;
                SecondsUpdated?.Invoke(_seconds);
            }
                
            TimeUpdated?.Invoke(_time);
        }
    }
}