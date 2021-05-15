using System;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.Utils.Components
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