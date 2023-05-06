using UnityEngine;

public class Player : MonoBehaviour
{
    const string MoveX = "Horizontal";
    const string MoveY = "Vertical";

    [SerializeField] private float _speed;

    private Vector2 _moveDirection;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw(MoveX);
        float moveY = Input.GetAxisRaw(MoveY);
        _moveDirection = new Vector2(moveX, moveY).normalized;

        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
}
