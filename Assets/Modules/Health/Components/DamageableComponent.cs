using System;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.Health
{
    public class DamageableComponent : MonoBehaviour
    {
        public UnityEvent<float> Damaged;

        public void GetDamage(float damage = 1f)
        {
            Damaged?.Invoke(damage);
        }
    }
}