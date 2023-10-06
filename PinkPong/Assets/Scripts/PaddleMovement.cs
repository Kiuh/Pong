using TMPro;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float dashTime;

    [SerializeField]
    private float dashSpeed;

    private float dashTimer;

    private RotationDirection dashRotateDirection;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private PaddleInput paddleInput;
    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField] private TMP_Text dashCD;

    [SerializeField]
    private float dashCoolDown;

    [SerializeField] private SpriteRenderer sprite;

    private float timer;

    public void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            dashCD.text = ((int)timer).ToString();
        }
        else
        {
            dashCD.text = "Dash ready!";
        }
        dashTimer -= Time.deltaTime;
        if (dashTimer > 0)
        {
            transform.RotateAround(
               target.position,
               Vector3.forward,
               Time.deltaTime
                   * dashSpeed
                   * (dashRotateDirection == RotationDirection.CounterClockWise ? -1 : 1)
           );
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
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
        dashRotateDirection = rotateDirection;
        dashTimer = dashTime;
        timer = dashCoolDown;
    }

    public void SetTransparent()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
    }

    public void SetNormalTransparency()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }
}
