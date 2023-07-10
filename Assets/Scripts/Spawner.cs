using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;

    private int _spawned;
    private float _passTime;

    private void Update()
    {
        _passTime += Time.deltaTime;

        StartCoroutine(Spawn(_delay));
    }

    private void InstantiateEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-_spawnPoint.position.x * 3, _spawnPoint.position.x * 3), 1, Random.Range(-_spawnPoint.position.z * 3, _spawnPoint.position.z * 3));

        Instantiate(_enemy, position, Quaternion.identity);
    }

    private IEnumerator Spawn(float timeBetweenSpawns)
    {
        if (_spawned < _count && _passTime >= _delay)
        {
            InstantiateEnemy();
            _spawned++;
            _passTime = 0;
        }

        yield return new WaitForSeconds(timeBetweenSpawns); ;
    }
}