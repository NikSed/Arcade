using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _bulletsContainer;
    [SerializeField] private float _rayMaxDistance = 50f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, _rayMaxDistance);

            if (hit.transform != null)
            {
                Vector3 target = (hit.transform.position - transform.position).normalized;
                BulletInstantiate(target);
            }
        }
    }

    private void BulletInstantiate(Vector3 target)
    {
        Transform _bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, _bulletsContainer);
        _bullet.GetComponent<Bullet>().Target = target;
    }
}