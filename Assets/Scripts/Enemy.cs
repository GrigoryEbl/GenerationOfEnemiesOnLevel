using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Transform _transform;
    private Spawner _spawner;
    private Transform _target;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _spawner = GetComponentInParent<Spawner>();
        _transform = transform;
        _target = _spawner.Target;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed;
        _transform.LookAt(_target);
    }
}
