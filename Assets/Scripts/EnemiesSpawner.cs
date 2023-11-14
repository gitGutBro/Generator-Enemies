using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyTemplate;
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _timeInSeconds;

    private List<Transform> _spawnPoints;
    private float _timer;

    private void Awake()
    {
        _spawnPoints = new List<Transform>();
        SpawnPoint[] spawnPoints = GetComponentsInChildren<SpawnPoint>();

        foreach (SpawnPoint spawnPoint in spawnPoints)
            _spawnPoints.Add(spawnPoint.transform);
    }

    private void Start()
        => _timer = _timeInSeconds;
    //
    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Instantiate(_enemyTemplate, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
            _enemyTemplate.SetTargetPosition(_target);
            _timer = _timeInSeconds;
        }
    }
}