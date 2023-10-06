using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private float maxInitAngle = 0.67f;

    [Range(0, 10)]
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float speedMultiplier = 1.1f;

    [SerializeField]
    private float startX = 0;

    [SerializeField]
    private float startY = 0;
    public UnityEvent<PaddleMovement> OnPaddleCollide;
    public UnityEvent OnZoneReached;

    public void AddForce()
    {
        Vector2 direction = Random.value < 0.5f ? Vector2.left : Vector2.right;
        direction.y = Random.Range(-maxInitAngle, maxInitAngle);
        rigidbody.velocity = direction * moveSpeed;
    }

    public void ResetBallPosition()
    {
        transform.position = new Vector2(startX, startY);
    }

    public void IncreaseSpeed()
    {
        rigidbody.velocity *= speedMultiplier;
    }

    public void ResetVelocity()
    {
        rigidbody.velocity = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone _))
        {
            OnZoneReached?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PaddleMovement paddle))
        {
            OnPaddleCollide?.Invoke(paddle);
        }
    }
}
