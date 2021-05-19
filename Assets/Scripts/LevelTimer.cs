using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class LevelTimer : ITickable
    {
        public Action<float> TimeUpdated;
        public Action<int> SecondsUpdated;

        public float Time => _time;
        private float _time;
        public int Seconds => _seconds;
        private int _seconds;
        
        public void Tick()
        {
            _time += UnityEngine.Time.deltaTime;

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