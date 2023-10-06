using TMPro;
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
    private GameObject gameEnd;

    [SerializeField]
    private TMP_Text win;

    [SerializeField]
    private Ball ball;

    [SerializeField]
    private GameObject pause;

    [SerializeField]
    private int maxScore;

    private bool locker = false;

    // Called by Ball
    public void OnPaddleCollide(PaddleMovement paddle)
    {
        paddle1.SetNormalTransparency();
        paddle2.SetNormalTransparency();
        lastHitPaddle = paddle;
        paddle.SetTransparent();
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
        if (scorePlayer1 == maxScore || scorePlayer2 == maxScore)
        {
            EndGame();
        }
        paddle1.SetNormalTransparency();
        paddle2.SetNormalTransparency();
    }

    private void Update()
    {
        if (!locker)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lastHitPaddle = paddle2;
                paddle2.SetTransparent();
                ball.AddForce();
                locker = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                paddle1.SetTransparent();
                lastHitPaddle = paddle1;
                ball.AddForce();
                locker = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    private void UpdateScore()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }

    private void EndGame()
    {
        gameEnd.SetActive(true);
        win.text = scorePlayer1 == maxScore ? "Player 1 won!" : "Player 2 won!";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        gameEnd.SetActive(false);
        ball.ResetBallPosition();
        ball.ResetVelocity();
        paddle1.ResetPosition();
        paddle2.ResetPosition();
        scorePlayer1 = scorePlayer2 = 0;
        UpdateScore();
    }
    public void OnPause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}
