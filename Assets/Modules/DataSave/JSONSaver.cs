using System.IO;
using UnityEngine;

namespace Plugins.DataSave
{
    public class JSONSaver<T> : SaverBase<T> where T : class, new()
    {
        private const string Extension = ".json";
        
        public override void Save()
        {
            File.WriteAllText(Path, JsonUtility.ToJson(Instance));
        }

        protected override T Load()
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(Path));
        }

        protected override string GetExtension()
        {
            return Extension;
        }
    }
}