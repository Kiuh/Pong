using UnityEngine;
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dashDistance;
    [SerializeField] private Transform target;
    [SerializeField] private PaddleInput paddleInput;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void Move(RotationDirection rotateDirection)
    {
        switch (rotateDirection)
        {
            case RotationDirection.ClockWise:
                transform.RotateAround(target.position, Vector3.forward, Time.deltaTime * speed);
                break;
            case RotationDirection.CounterClockWise:
                transform.RotateAround(target.position, Vector3.forward, Time.deltaTime * speed * -1);
                break;
        }

    }

    public void Dash(RotationDirection rotateDirection)
    {
        switch (rotateDirection)
        {
            case RotationDirection.ClockWise:
                transform.RotateAround(target.position, Vector3.forward, dashDistance * speed);
                break;
            case RotationDirection.CounterClockWise:
                transform.RotateAround(target.position, Vector3.forward, dashDistance * speed * -1);
                break;
        }
    }
}