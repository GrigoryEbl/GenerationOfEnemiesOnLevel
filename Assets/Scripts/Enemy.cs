using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Transform _transform;
    private Transform _target;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            _rigidbody.velocity = _transform.forward * _speed;
            _transform.LookAt(_target);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
