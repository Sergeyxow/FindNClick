using System;
using UnityEngine;

namespace Modules.ServiceLocator
{
    public class ServiceSetter : MonoBehaviour
    {
        public UnityEngine.Object[] Objects;

        private void Start()
        {
            foreach (var o in Objects)
            {
                Type type = o.GetType();
                Service.Set(type, o);
            }
        }
    }
}