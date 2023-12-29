using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;
    [SerializeField] private float _spawnRadius;
    [SerializeField] Transform _target;

    private Transform _transform;
    private int _spawned;
    private float _passTime;
    private WaitForSeconds _sleepTime;

    public Transform Target => _target;

    private void Start()
    {
        _transform = transform;
        _sleepTime = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        _passTime += Time.deltaTime;

        StartCoroutine(Spawn(_sleepTime));
    }

    private void InstantiateEnemy()
    {
        float heightByY = 0.1f;

        Vector3 position = new Vector3(Random.Range(_transform.position.x, _transform.position.x + _spawnRadius),
                                        heightByY,
                                        Random.Range(_transform.position.z, _transform.position.z + _spawnRadius));

        Instantiate(_enemy, position, Quaternion.identity, _transform);
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