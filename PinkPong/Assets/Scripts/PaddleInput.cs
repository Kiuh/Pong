using UnityEngine;

public class PaddleInput : MonoBehaviour
{
    [SerializeField] private string inputButton;
    [SerializeField] private PaddleMovement movement;
    [SerializeField] private float delayBetweenPresses;
    private bool pressedFirstTime = false;
    private float lastPressedTime;

    private void Update()
    {
        RotationDirection direction = (Input.GetAxis(inputButton) > 0) ? RotationDirection.ClockWise : RotationDirection.CounterClockWise;
        if (Input.GetButtonUp(inputButton))
        {
            DoublePressCheck(direction);
        }
        if (Input.GetButton(inputButton))
        {
            movement.Move(direction);
        }
    }

    private void DoublePressCheck(RotationDirection direction)
    {
        if (pressedFirstTime)
        {
            if (Time.time - lastPressedTime <= delayBetweenPresses)
            {
                movement.Dash(direction);
            }
            pressedFirstTime = !pressedFirstTime;
        }

        lastPressedTime = Time.time;
        pressedFirstTime = !pressedFirstTime;

        if (pressedFirstTime && Time.time - lastPressedTime > delayBetweenPresses)
        {
            pressedFirstTime = !pressedFirstTime;
        }
    }
}

public enum RotationDirection
{
    ClockWise = 1,
    CounterClockWise = -1
}