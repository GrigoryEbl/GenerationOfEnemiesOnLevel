using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            StartCoroutine(Spawn(_currentWave.Delay));

            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-_spawnPoint.position.x * 3, _spawnPoint.position.x * 3), 1, Random.Range(-_spawnPoint.position.z * 3, _spawnPoint.position.z * 3));

        Instantiate(_currentWave.Template, position, Quaternion.identity);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private IEnumerator Spawn(float timeBetweenSpawns)
    {
        WaitForSeconds waitOneSeconds = new WaitForSeconds(timeBetweenSpawns);

        InstantiateEnemy();

        yield return waitOneSeconds;
    }
}

[System.Serializable]

public class Wave
{
    public Enemy Template;
    public float Delay;
    public int Count;
}