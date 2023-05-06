using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private UnityEvent _leaved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _reached.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _leaved.Invoke();
        }
    }
}
