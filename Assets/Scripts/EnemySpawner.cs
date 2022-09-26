using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject[] _enemiesScriptableObjectArray;

    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _enemiesContainer;

    [SerializeField] private int _maxEnemiesOnScene = 5;
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private float _spawnXMin = -8f;
    [SerializeField] private float _spawnXMax = 8f;
    [SerializeField] private float _spawnYMin = 4f;
    [SerializeField] private float _spawnYMax = 8f;
    [SerializeField] private float _spawnZ = 0;

    private int _enemiesOnScene = 0;

    System.Random random = new System.Random();

    private void Awake()
    {
        GlobalEventsManager.OnEnemyDestroy.AddListener(OnEnemyDestroy);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void OnEnemyDestroy()
    {
        _enemiesOnScene--;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemiesOnScene < _maxEnemiesOnScene)
            {
                EnemyInstantiate();
                _enemiesOnScene++;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void EnemyInstantiate()
    {
        var enemy = Instantiate(_enemyPrefab, RandomSpawnPosition(), Quaternion.identity, _enemiesContainer);
        enemy.GetComponent<Enemy>().Setup(GetRandomEnemyScriptableObject());
    }

    private EnemyScriptableObject GetRandomEnemyScriptableObject()
    {
        int randomIndex = random.Next(0, _enemiesScriptableObjectArray.Length);
        return _enemiesScriptableObjectArray[randomIndex];
    }

    private Vector3 RandomSpawnPosition()
    {
        float rangeX = _spawnXMax - _spawnXMin;
        float rangeY = _spawnYMax - _spawnYMin;

        double sample = random.NextDouble();
        double scaledX = (sample * rangeX) + _spawnXMin;
        double scaledY = (sample * rangeY) + _spawnYMin;

        return new Vector3((float)scaledX, (float)scaledY, _spawnZ);
    }
}