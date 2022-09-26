using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletsContainer;
    [SerializeField] private float _rayMaxDistance = 50f;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, _rayMaxDistance) && !hit.transform.CompareTag("Player"))
                SpawnBullet(hit.transform);
        }
    }

    private void SpawnBullet(Transform target)
    {
        Vector3 position = transform.position;
        Vector3 directionToTarget = (target.position - position).normalized;

        Bullet bullet = Instantiate(_bulletPrefab, position, Quaternion.identity, _bulletsContainer);
        bullet.Setup(directionToTarget);
    }
}