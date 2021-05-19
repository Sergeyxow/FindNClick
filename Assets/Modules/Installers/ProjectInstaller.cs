using DefaultNamespace;
using Modules.Data;
using Plugins.DataSave;
using UnityEngine;
using Zenject;

namespace Modules.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private LevelCollection _levelCollection;
        
        [SerializeField] private LevelDescriptionCollection _levelDescriptionCollection;
        [SerializeField] private LevelGameplayDataCollection _levelGameplayDataCollection;

        public override void InstallBindings()
        {
            Container.Bind<GameData>().FromInstance(_gameData).AsSingle();
            Container.Bind<LevelCollection>().FromInstance(_levelCollection).AsSingle();
            
            Container.Bind<LevelDescriptionCollection>().FromInstance(_levelDescriptionCollection).AsSingle();
            Container.Bind<LevelGameplayDataCollection>().FromInstance(_levelGameplayDataCollection).AsSingle();
            
            Container.Bind<SessionData>().To<SessionData>().AsSingle();
            Container.Bind<SaverBase<PlayerData>>().To<JSONSaver<PlayerData>>().AsSingle();
            Container.Bind<SaverBase<LevelStatisticsArray>>().To<JSONSaver<LevelStatisticsArray>>().AsSingle();
        }
    }
}