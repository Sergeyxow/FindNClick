using System.IO;
using UnityEngine;

namespace Plugins.DataSave
{
    public abstract class SaverBase<T> where T : class, new()
    {
        public T Instance
        {
            get => GetOrCreateInstance();
            set => instance = value;
        }

        private T instance;
        
        protected string Path => $"{Application.persistentDataPath}/{typeof(T).Name}" + GetExtension();
        
        public abstract void Save();


        /// <summary>
        /// Clears the data just in runtime.
        /// Note: To clear file you need to call Save() method
        /// </summary>
        public void Clear()
        {
            instance = null;
        }

        private T GetOrCreateInstance()
        {
            if (instance == null)
                instance = LoadOrCreate();
            return instance;
        }

        private T LoadOrCreate()
        {
            if (File.Exists(Path))
            {
                try
                {
                    return Load();
                }
                catch
                {
                    return new T();
                }
            }

            return new T();
        }

        protected abstract T Load();

        protected abstract string GetExtension();
    }
}
