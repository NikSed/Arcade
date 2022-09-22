using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.25f;
    [SerializeField] private float _moveMinX = -8f;
    [SerializeField] private float _moveMaxX = 8f;

    void FixedUpdate()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");

        if (_inputX != 0)
        {
            Vector2 turgetPosition = new Vector2(transform.position.x + _inputX * _speed, transform.position.y);
            transform.position = turgetPosition;

            if (transform.position.x < _moveMinX)
            {
                transform.position = new Vector2(_moveMinX, transform.position.y);
                return;
            }

            if (transform.position.x > _moveMaxX)
            {
                transform.position = new Vector2(_moveMaxX, transform.position.y);
                return;
            }
        }
    }
}