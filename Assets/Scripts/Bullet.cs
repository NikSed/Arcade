using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _percentDamage = 25f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private float _moveSpeed = 6f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    public void Setup(Vector3 direction)
    {
        _rigidbody.velocity = direction * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && other.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(_percentDamage);

            Destroy(gameObject);
        }
    }
}