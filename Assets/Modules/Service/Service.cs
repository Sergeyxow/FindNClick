using System;
using System.Collections.Generic;

namespace Modules.ServiceLocator
{
    public sealed class Service
    {
        private static Dictionary<Type, Object> _dictionary = new Dictionary<Type, object>(10);
        
        public static bool Get<T> (out T value, bool createIfNotExists = false)
        {
            foreach (var pair in _dictionary)
            {
                if (pair.Key == typeof(T))
                {
                    value = (T)pair.Value;
                    return true;
                }
            }

            if (createIfNotExists)
            {
                value = (T) Activator.CreateInstance(typeof(T), true);
                return true;
            }

            value = default(T);
            return false;
        }

        public static void Set<T>(T value)
        {
            Set(typeof(T), value);
        }
        
        public static void Set(Type type, Object value)
        {
            if (_dictionary.ContainsKey(type))
            {
                _dictionary[type] = value;
            }
            else
            {
                _dictionary.Add(type, value);
            }
        }
    }
}