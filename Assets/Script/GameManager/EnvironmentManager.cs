using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnvironmentManager : MonoBehaviour
{

    [Header("DATA")] 
    [SerializeField] private DataEnemy _dataEnemy;
    
    
    [Header("TANK")] 
    [SerializeField] private TankController _tankPrefab;
    [SerializeField] private Transform _playerSpawnPos;
    
    [Header("ENEMY")] 
    [SerializeField] private EnemyBehaviour _enemyPrefab;
    [SerializeField] private Transform _enemySpawnPos;
 

    [Header("BOSS")] 
    [SerializeField] private BossManager _bossPrefab;
    [SerializeField] private Transform _bossSpawnPos;

    

    [Header("MOVE WAVE")]
    [SerializeField] private Transform[] _startPoints;
    [SerializeField] private Transform[] _controlPoints;
    [SerializeField] private Transform[] _endPoints;
    [SerializeField] private float _timeMove;
    
    [Header("SPAWN WAVE SETTINGS")]
    [SerializeField] private int _numWaves;
    [SerializeField] private float _timeBetweenWaves;

    [Header("POWER ITEM")] 
    [SerializeField] private GameObject _powerItems;



    private async void Start()
    {
  
        SpawnTank();
        await UniTask.Delay(3000);
        SpawnPower();
        await SpawnWaves();
        
    }

    // Spawn Tank
    private void SpawnTank()
    { 
        TankController tank =  Instantiate(_tankPrefab, _playerSpawnPos.position, Quaternion.identity);
        tank.transform.DOMoveX(0, 1f);
        tank.transform.DOMoveY(-4f, 2f);
    }
    
    private void SpawnBoss()
    { 
        BossManager boss =  Instantiate(_bossPrefab, _bossSpawnPos.position, Quaternion.Euler(0,0,-180f));
        //boss.transform.DOMoveX(0, 1f);
        boss.transform.DOMoveY(3, 2f);
    }
    // Spawn Waves Enemy
    private async UniTask SpawnWaves()
    {
        for (int waveIndex = 0; waveIndex < _numWaves; waveIndex++)
        {
            await SpawnEnemy();
            if (waveIndex < _numWaves - 1)
            {
                await UniTask.Delay((int)(_timeBetweenWaves * 1000));
            }
        }

        SpawnBoss();
    }
    
    // Spawn Enemy
    private  async UniTask SpawnEnemy()
    {
        for (int i = 0; i < _dataEnemy.Enemys.Count; i++)
        {
            EnemyBehaviour enemy =  Instantiate(_enemyPrefab, _enemySpawnPos.position, Quaternion.Euler(0,0,-180f));
            EnemyMove(enemy);
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            enemyBehaviour.DataEnemy(_dataEnemy.Enemys[i]);
            await UniTask.Delay(2500);
        }
    }
    
    // Spawn PowerItem
    private async void SpawnPower()
    {
        while (true)
        {
            Instantiate(_powerItems,new Vector2(Random.Range(-2f,2f),5f),quaternion.identity);
            await UniTask.Delay(10000);
        }
    }

    // Draw a line for Enemy
    private void EnemyMove(EnemyBehaviour enemy)
    {
        if (_startPoints.Length == 0 || _endPoints.Length == 0 || _controlPoints.Length == 0)
        {
            return;
        }
        int randomIndex = Random.Range(0, Mathf.Min(_startPoints.Length, _endPoints.Length, _controlPoints.Length));
        Vector3[] path = new Vector3[] { _startPoints[randomIndex].position, _controlPoints[randomIndex].position, _endPoints[randomIndex].position };
        enemy.transform.DOPath(path, _timeMove, PathType.CatmullRom, PathMode.TopDown2D).SetEase(Ease.Linear).OnComplete(() => Destroy(enemy.gameObject));
    }
    
}
