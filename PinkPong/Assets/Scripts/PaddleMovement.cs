using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float dashDistance;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private PaddleInput paddleInput;
    private Vector3 startPosition;

    [SerializeField]
    private float dashCoolDown;

    private float timer;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void Move(RotationDirection rotateDirection)
    {
        transform.RotateAround(
            target.position,
            Vector3.forward,
            Time.deltaTime
                * speed
                * (rotateDirection == RotationDirection.CounterClockWise ? -1 : 1)
        );
    }

    public void Dash(RotationDirection rotateDirection)
    {
        if (timer > 0)
        {
            return;
        }
        transform.RotateAround(
            target.position,
            Vector3.forward,
            dashDistance * (rotateDirection == RotationDirection.CounterClockWise ? -1 : 1)
        );
        timer = dashCoolDown;
    }
}
