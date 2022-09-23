using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletsContainer;
    [SerializeField] private float _rayMaxDistance = 50f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _rayMaxDistance))
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