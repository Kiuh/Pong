using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private string inputButton;

    [SerializeField] private float speed;

    [SerializeField] private Transform target;

    [SerializeField] private GameManager gameManager;

    [Range(0, 2)] public int ID;

    private Vector3 startPosition;

    private float delayBetweenPresses = 0.25f;
    private bool pressedFirstTime = false;
    private float lastPressedTime;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void ResetPaddle()
    {
        transform.position = startPosition;
    }

    public void Update()
    {
        if (Input.GetButton(inputButton))
        {
            if (pressedFirstTime)
            {
                bool isDoublePress = Time.time - lastPressedTime <= delayBetweenPresses;
                if (isDoublePress)
                {
                    pressedFirstTime = false;
                    Dash(Input.GetAxis(inputButton));
                    Debug.Log("dash");
                }
            }
            else
            {
                pressedFirstTime = true;
                Debug.Log("move");
                Move(Input.GetAxis(inputButton));
            }

            lastPressedTime = Time.time;
        }

        if (pressedFirstTime && Time.time - lastPressedTime > delayBetweenPresses)
        {
            pressedFirstTime = false;
        }
    }

    private void Move(float movement)
    {
        transform.RotateAround(target.position, new Vector3(0, 0, 1) * movement, Time.deltaTime * speed);
    }

    private void Dash(float movement)
    {
        transform.RotateAround(target.position, new Vector3(0, 0, 1) * movement, Time.deltaTime * speed);
    }
}