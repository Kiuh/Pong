using System;
using UnityEngine;

public class PaddleInput : MonoBehaviour
{
    [SerializeField] private string inputButton;
    [SerializeField] private PaddleMovement movement;
    [SerializeField] private float delayBetweenPresses;
    private bool pressedFirstTime = false;
    private float lastPressedTime;

    public event Action<float> IsDoublePressed;

    private void Update()
    {
        if (Input.GetButtonUp(inputButton))
        {
            DoublePressCheck(Input.GetAxis(inputButton));
        }

        if (Input.GetButton(inputButton))
        {
            movement.Move(Input.GetAxis(inputButton));
        }
    }

    private void DoublePressCheck(float direction)
    {
        if (pressedFirstTime)
        {
            if (Time.time - lastPressedTime <= delayBetweenPresses)
            {
                IsDoublePressed?.Invoke(direction);
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