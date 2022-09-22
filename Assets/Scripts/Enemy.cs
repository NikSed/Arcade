using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private float _currentHealth;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private int _timeToGrow = 5;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _percentDamage = 25f;
    [SerializeField] private int _startPercentScale = 10;

    private Transform _player;

    private bool _isMaxScale = false;

    private Vector3 _maxScale;
    private Vector3 _startScale;

    private void Awake()
    {
        _maxScale = transform.localScale;
        _startScale = new Vector3(_maxScale.x * _startPercentScale / 100, _maxScale.y * _startPercentScale / 100, _maxScale.z * _startPercentScale / 100);
        transform.localScale = _startScale;

        _currentHealth = _maxHealth;

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        StartCoroutine(Grow());
    }

    private void OnDestroy()
    {
        GlobalEventsManager.OnEnemyDestroy.Invoke();
    }

    private void FixedUpdate()
    {
        if (_isMaxScale && _player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(_percentDamage);
            Destroy(gameObject);
        }
    }

    private IEnumerator Grow()
    {
        float timer = 0f;

        while (timer < _timeToGrow)
        {
            transform.localScale = Vector3.Lerp(_startScale, _maxScale, timer / _timeToGrow);
            timer += Time.deltaTime;

            yield return null;
        }

        _isMaxScale = true;
    }

    public void GetDamage(float damage)
    {
        if (damage > 0 && _isMaxScale)
        {
            _currentHealth -= _maxHealth * damage / 100;
        }

        if (_currentHealth <= 0)
        {
            GlobalEventsManager.OnEnemyKill.Invoke();
            Destroy(gameObject);
        }
    }
}