using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float maxInitAngle = 0.67f;

    [Range(0, 10)]
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float speedMultiplier = 1.1f;

    private float startX = 0;
    private float maxStartY = 4f;

    private void Start()
    {
        InitialPush();
        GameManager.Instance.OnReset += ResetBall;
    }

    private void InitialPush()
    {
        Vector2 direction = Random.value < 0.5f ? Vector2.left : Vector2.right;
        direction.y = Random.Range(-maxInitAngle, maxInitAngle);
        rb2d.velocity = direction * moveSpeed;
    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }

    private void ResetBallPosition()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            GameManager.Instance.OnScoreZoneReached(scoreZone.ID);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            rb2d.velocity *= speedMultiplier;
        }
    }
}
