using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputManager : MonoBehaviour, IUserInput
{
    public event Action<Vector2> OnMove;
    public event Action<float> OnBrake;
    public event Action<float> OnDrift;

    public void OnMoveAction(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnBrakeAction(InputAction.CallbackContext context)
    {
        OnBrake?.Invoke(context.ReadValue<float>());
    }

    public void OnDriftAction(InputAction.CallbackContext context)
    {
        OnDrift?.Invoke(context.ReadValue<float>());
    }
}