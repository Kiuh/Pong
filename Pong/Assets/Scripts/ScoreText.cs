using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Animator Animator;

    public void Highlight()
    {
        Animator.SetTrigger("Highlight");
    }

    public void SetScore(int value)
    {
        Text.text = value.ToString();
    }
}
