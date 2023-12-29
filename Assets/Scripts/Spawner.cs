using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Target _target;

    private Transform _transform;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _transform = transform;
        _sleepTime = new WaitForSeconds(_delay);
       
        StartCoroutine(Spawn(_sleepTime));
    }

    private void InstantiateEnemy()
    {
        float heightByY = 0.1f;

        Vector3 position = new Vector3(Random.Range(_transform.localPosition.x - _spawnRadius, _transform.localPosition.x + _spawnRadius),
                                        heightByY,
                                        Random.Range(_transform.localPosition.z - _spawnRadius, _transform.localPosition.z + _spawnRadius));

        Instantiate(_enemy, position, Quaternion.identity, _transform);
    }

    private IEnumerator Spawn(WaitForSeconds timeBetweenSpawns)
    {
        for (int i = 0; i < _count; i++)
        {
            InstantiateEnemy();
            _enemy.SetTarget(_target.transform);
            yield return timeBetweenSpawns;
           
        }
    }
}