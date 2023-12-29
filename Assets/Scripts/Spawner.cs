using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;
    [SerializeField] private float _spawnRadius;
    [SerializeField] Transform _target;

    private Transform _transform;
    private int _spawnedCount;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _transform = transform;
        _sleepTime = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
       
    }

    private void InstantiateEnemy()
    {
        float heightByY = 0.1f;

        Vector3 position = new Vector3(Random.Range(-_transform.position.x, _transform.position.x + _spawnRadius),
                                        heightByY,
                                        Random.Range(-_transform.position.z, _transform.position.z + _spawnRadius));

        Instantiate(_enemy, position, Quaternion.identity, _transform);

    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            InstantiateEnemy();
            _spawnedCount++;
            _enemy.SetTarget(_target);
            yield return new WaitForSeconds(_delay) ;
        }

        yield return null;
    }

    
}