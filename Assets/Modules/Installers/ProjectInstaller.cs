using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using Zenject;

namespace Modules.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;

        public override void InstallBindings()
        {
            Container.Bind<GameData>().FromInstance(_gameData).AsSingle();
            
            Container.Bind<SessionData>().To<SessionData>().AsSingle();
            Container.Bind<SaverBase<PlayerData>>().To<JSONSaver<PlayerData>>().AsSingle();
        }
    }
}