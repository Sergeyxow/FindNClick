using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Common;
using DefaultNamespace.UI;
using Modules.Data;
using UnityEngine;
using Zenject;

public class MenuController : MonoBehaviour
{
    [SerializeField] private RectTransform _levelsParent;
    [SerializeField] private LevelPopup _levelPopup;
    [SerializeField] private LevelBox _levelBoxPrefab;

    private LevelCollection _levelCollection;
    private LevelDescriptionCollection _levelDescriptionCollection;
    private LevelStatisticsCollection _levelStatisticsCollection;

    private Dictionary<int, (LevelDescription, LevelStatistics)> _dictionary = new Dictionary<int, (LevelDescription, LevelStatistics)>();
    
    [Inject]
    private void Construct(
        LevelCollection levelCollection, 
        LevelDescriptionCollection levelDescriptionCollection, 
        LevelStatisticsCollection levelStatisticsCollection)
    {
        _levelStatisticsCollection = levelStatisticsCollection;
        _levelDescriptionCollection = levelDescriptionCollection;
        _levelCollection = levelCollection;
    }
    

    private void Start()
    {
        foreach (int levelId in _levelCollection.Levels)
        {
            if (_levelDescriptionCollection.TryGetDescription(levelId, out LevelDescription description))
            {
                if (_levelStatisticsCollection.TryGetStatistics(levelId, out LevelStatistics statistics))
                {
                    _dictionary.Add(levelId, (description, statistics));
                    
                    InstantiateLevelBox(levelId, description, statistics);
                }
            }
        }
    }

    private void InstantiateLevelBox(int id, LevelDescription description, LevelStatistics statistics)
    {
        LevelBox levelBox = Instantiate(_levelBoxPrefab, _levelsParent);
        levelBox.Init(id, description, statistics);
        levelBox.Clicked += ShowPopup;
    }

    private void ShowPopup(int id)
    {
        (LevelDescription, LevelStatistics) levelData = _dictionary[id];
        
        _levelPopup.Show();
        _levelPopup.UpdateInformation(id, levelData.Item1, levelData.Item2);
    }
}
