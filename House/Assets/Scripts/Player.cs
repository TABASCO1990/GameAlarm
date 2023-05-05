using UnityEngine;

public class Player : MonoBehaviour
{
    const string MoveX = "Horizontal";
    const string MoveY = "Vertical";

    [SerializeField] private float _speed;

    private Vector2 moveDirection;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw(MoveX);
        float moveY = Input.GetAxisRaw(MoveY);
        moveDirection = new Vector2(moveX, moveY).normalized;

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }
}
