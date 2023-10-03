using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private string inputButton;

    [SerializeField] private float speed;

    [SerializeField] private Transform target;

    [SerializeField] private GameManager gameManager;

    private Vector3 startPosition;

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
            Move(Input.GetAxis(inputButton));
        }
    }

    private void Move(float movement)
    {
        transform.RotateAround(target.position, new Vector3(0, 0, 1) * movement, Time.deltaTime * speed);
    }
}