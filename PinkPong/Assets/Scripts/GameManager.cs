using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public System.Action OnReset;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game Manager is Null");
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
}