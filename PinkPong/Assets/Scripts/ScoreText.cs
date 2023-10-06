using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public void SetScore(int value)
    {
        Text.text = value.ToString();
    }
}
