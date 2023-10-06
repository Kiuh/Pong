using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScoreText scoreTextLeft;

    [SerializeField]
    private ScoreText scoreTextRight;

    [SerializeField]
    private int scorePlayer1;

    [SerializeField]
    private int scorePlayer2;

    [SerializeField]
    private PaddleMovement paddle1;

    [SerializeField]
    private PaddleMovement paddle2;
    private PaddleMovement lastHitPaddle;

    [SerializeField]
    private Ball ball;

    private bool locker = false;

    // Called by Ball
    public void OnPaddleCollide(PaddleMovement paddle)
    {
        lastHitPaddle = paddle;
        ball.IncreaseSpeed();
    }

    // Called by Ball
    public void OnZoneReached()
    {
        ball.ResetBallPosition();
        ball.ResetVelocity();
        if (lastHitPaddle == paddle1)
        {
            scorePlayer1++;
        }
        else
        {
            scorePlayer2++;
        }
        locker = false;
        UpdateScore();
    }

    private void Update()
    {
        if (!locker)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lastHitPaddle = paddle2;
                ball.AddForce();
                locker = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                lastHitPaddle = paddle1;
                ball.AddForce();
                locker = true;
            }
        }
    }
    private void UpdateScore()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }
}
