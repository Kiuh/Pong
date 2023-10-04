using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private PaddleInput input;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private Transform target;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        input.IsDoublePressed += Dash;
    }

    private void OnDisable()
    {
        input.IsDoublePressed -= Dash;
    }

    public void ResetPaddle()
    {
        transform.position = startPosition;
    }

    public void Move(float movement)
    {
        transform.RotateAround(target.position, new Vector3(0, 0, 1) * movement, Time.deltaTime * speed);
    }

    private void Dash(float movement)
    {
        transform.RotateAround(target.position, new Vector3(0, 0, 1) * movement, Time.deltaTime * dashSpeed);
    }
}