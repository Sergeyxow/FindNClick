using DefaultNamespace;
using Modules.Core;
using Modules.Data;
using UnityEngine;
using Zenject;

namespace Modules.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private LevelController _levelController;

        public override void InstallBindings()
        {
            Container.Bind<LevelData>().FromInstance(_levelData).AsSingle();
            Container.Bind<LevelController>().FromInstance(_levelController).AsSingle();
            
            Container.BindInterfacesAndSelfTo<LevelTimer>().AsSingle();
        }
    }
}