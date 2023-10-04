using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float maxInitAngle = 0.67f;
    [Range(0, 10)][SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float speedMultiplier = 1.1f;
    private readonly float startX = 0;
    private readonly float maxStartY = 4f;

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
        Vector2 position = new(startX, posY);
        transform.position = position;
    }
}

//ÿ õç êàê ýòî ñäåëàòü àäåêâàòíî ÷åñòíî 
//private void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.gameObject.name == "ScoreZone")
//    {
//        Paddle paddle = collision.GetComponent<Paddle>();
//        if (paddle)
//        {
//            GameManager.Instance.OnScoreZoneReached(paddle.ID);
//        }
//        else
//        {
//            rb2d = GetComponent<Rigidbody2D>();
//            if (rb2d.velocity.x > 0)
//            {
//                GameManager.Instance.OnScoreZoneReached(1);
//            }
//            else
//            {
//                GameManager.Instance.OnScoreZoneReached(2);
//            }
//        }
//    }
//}

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        Paddle paddle = collision.collider.GetComponent<Paddle>();
//        if (paddle)
//        {
//            rb2d.velocity *= speedMultiplier;
//        }
//    }
//}
