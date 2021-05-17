using System;
using System.Collections;
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
    [SerializeField] private LevelBox _levelBoxPrefab;

    private LevelCollection _levelCollection;
    private LevelDescriptionCollection _levelDescriptionCollection;
    private LevelStatisticsCollection _levelStatisticsCollection;

    [Inject]
    private void Construct(LevelCollection levelCollection, 
        LevelDescriptionCollection levelDescriptionCollection, LevelStatisticsCollection levelStatisticsCollection)
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
                    InstantiateLevelBox(levelId, description, statistics);
                }
            }
        }
    }

    private void InstantiateLevelBox(int id, LevelDescription description, LevelStatistics statistics)
    {
        Instantiate(_levelBoxPrefab, _levelsParent).Init(id, description, statistics);
    }
}
