using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame;
using CommonGame.Events;
namespace MyGame
{
    public class LevelInitializer : LevelInitBase
    {

        [SerializeField] private LevelStartChannelSO _startChannel;
        [Space(10)]
        public bool SpawnPlayer = true;
        public bool SpawnCrystals = true;
        public bool SpawnEnemies = true;

        [SerializeField] private MapWithEnemies _levelMap;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private CrystalSpawner _crystalSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        public override LevelStateSO InitLevel()
        {
            _crystalSpawner?.Init(_levelMap);
            _enemySpawner?.Init(_levelMap);
            _playerSpawner?.SpawnPlayer();
            _startChannel.OnLevelStarted += StartLevel;
            return _myState;
        }
        public void OnDisable()
        {
            _startChannel.OnLevelStarted -= StartLevel;
        }
        public override void StartLevel()
        {
            if(SpawnCrystals)
                _crystalSpawner.StartSpawner();
            if (SpawnEnemies)
                _enemySpawner.StartSpawner();
            _playerSpawner?.EnablePlayer();


        }


    }
}