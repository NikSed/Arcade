using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _moveSpeed = 0.15f;
    [SerializeField] private float _moveXMin = -8f;
    [SerializeField] private float _moveXMax = 8f;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");

        if (_inputX != 0)
        {
            Vector2 turgetPosition = new Vector2(transform.position.x + _inputX * _moveSpeed, transform.position.y);
            transform.position = turgetPosition;

            if (transform.position.x < _moveXMin)
            {
                transform.position = new Vector2(_moveXMin, transform.position.y);
                return;
            }

            if (transform.position.x > _moveXMax)
            {
                transform.position = new Vector2(_moveXMax, transform.position.y);
                return;
            }
        }
    }

    public void GetDamage(float damage)
    {
        if (damage > 0)
        {
            _currentHealth -= _maxHealth * damage / 100;
        }

        if (_currentHealth <= 0)
        {
            GlobalEventsManager.OnPlayerKill?.Invoke();
            Destroy(gameObject);
        }
    }
}