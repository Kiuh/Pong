using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int scorePlayer1,
        scorePlayer2;
    //public ScoreText ScoreTextLeft,
    //    ScoreTextRight;
    public System.Action OnReset;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnScoreZoneReached(int id)
    {
        OnReset?.Invoke();

        if (id == 1)
        {
            scorePlayer1++;
        }

        if (id == 2)
        {
            scorePlayer2++;
        }

        //UpdateScore();
        //HighlightScore(id);
    }

    //private void UpdateScore()
    //{
    //    ScoreTextLeft.SetScore(scorePlayer1);
    //    ScoreTextRight.SetScore(scorePlayer2);
    //}

    //public void HighlightScore(int id)
    //{
    //    if (id == 1)
    //        ScoreTextLeft.Highlight();
    //    else
    //        ScoreTextRight.Highlight();
    //}
}