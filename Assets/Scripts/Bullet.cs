using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _percentDamage = 25;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _moveSpeed = 3f;

    public Vector3 Target { get; set; }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && other.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(_percentDamage);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, _moveSpeed * Time.deltaTime);
    }
}