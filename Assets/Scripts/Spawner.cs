using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;
    [SerializeField] private int _spawnRadius;


    private int _spawned;
    private float _passTime;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        _passTime += Time.deltaTime;

        StartCoroutine(Spawn(_sleepTime));
    }

    private void InstantiateEnemy()
    {
        float heightByY = 1;

        Vector3 position = new Vector3(Random.Range(-_spawnPoint.position.x - _spawnRadius, _spawnPoint.position.x + _spawnRadius),+
                                        heightByY,+
                                        Random.Range(-_spawnPoint.position.z - _spawnRadius, _spawnPoint.position.z + _spawnRadius));

        Instantiate(_enemy, position, Quaternion.identity);
    }

    private IEnumerator Spawn(WaitForSeconds timeBetweenSpawns)
    {
        if (_spawned < _count && _passTime >= _delay)
        {
            InstantiateEnemy();
            _spawned++;
            _passTime = 0;
        }

        yield return timeBetweenSpawns; 
    }
}