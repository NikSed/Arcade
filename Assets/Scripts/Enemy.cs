using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _timeToGrow = 5;
    [SerializeField] private int _startPercentScale = 10;

    private Vector3 _baseScale;
    private Vector3 _startScale;

    private void Start()
    {
        _baseScale = transform.localScale;
        _startScale = new Vector3(_baseScale.x * _startPercentScale / 100, _baseScale.y * _startPercentScale / 100, _baseScale.z * _startPercentScale / 100);
        transform.localScale = _startScale;
    }
    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        GlobalEventsManager.OnEnemyDestroy.Invoke();
    }
}