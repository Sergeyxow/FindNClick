using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class JumpInsideAreaComponent : MonoBehaviour
    {
        [SerializeField] public bool CanMove = true;
        [SerializeField] private Transform _target;
        [SerializeField] private Area _area;

        public void Jump()
        {
            if (!CanMove)
                return;
            
            _target.position = _area.GetRandomPoint();
        }
    }
}