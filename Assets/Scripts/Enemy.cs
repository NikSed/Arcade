using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _baseHealth;
    [SerializeField] private float _baseArmor;
    [SerializeField] private float _baseMoveSpeed;
    [SerializeField] private float _basePercentDamage;
    [SerializeField] private float _baseStartPercentScale;
    [SerializeField] private float _baseGrowTime;

    [SerializeField] private float _currentHealth;
    [SerializeField] private bool _isMaxScale;

    private Transform _player;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;


    private Vector3 _maxScale;
    private Vector3 _startScale;

    public void Setup(EnemyScriptableObject enemyScriptableObject)
    {
        _meshFilter.mesh = enemyScriptableObject.Mesh;
        _meshRenderer.material = enemyScriptableObject.Material;
        _baseHealth = enemyScriptableObject.BaseHealth;
        _baseArmor = enemyScriptableObject.BaseArmor;
        _baseMoveSpeed = enemyScriptableObject.BaseMoveSpeed;
        _basePercentDamage = enemyScriptableObject.BasePercentDamage;
        _baseStartPercentScale = enemyScriptableObject.BaseStartPercentScale;
        _baseGrowTime = enemyScriptableObject.BaseGrowTime;
    }

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Start()
    {
        _maxScale = transform.localScale;
        _startScale = new Vector3(_maxScale.x * _baseStartPercentScale / 100, _maxScale.y * _baseStartPercentScale / 100, _maxScale.z * _baseStartPercentScale / 100);
        transform.localScale = _startScale;
        _currentHealth = _baseHealth;

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
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _baseMoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(_basePercentDamage);
            Destroy(gameObject);
        }
    }

    private IEnumerator Grow()
    {
        float timer = 0f;
        _isMaxScale = false;

        while (timer < _baseGrowTime)
        {
            transform.localScale = Vector3.Lerp(_startScale, _maxScale, timer / _baseGrowTime);
            timer += Time.deltaTime;

            yield return null;
        }

        _isMaxScale = true;
    }

    public void GetDamage(float damage)
    {
        if (damage > 0 && _isMaxScale)
        {
            damage -= damage * _baseArmor / 100;
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                GlobalEventsManager.OnEnemyKill.Invoke();
                Destroy(gameObject);
            }
        }
    }
}