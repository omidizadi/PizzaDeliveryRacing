using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStateHandler : MonoBehaviour
{
    public enum CarState
    {
        RearWheelDrive,
        FrontWheelDrive,
        FourWheelDrive
    }

    public CarState currentState;

    [SerializeField] private CarController carController;

    private void Awake()
    {
        ChangeState();
    }

    public void ChangeState()
    {
        var simpleDriftController = new DriftController();
        switch (currentState)
        {
            case CarState.FourWheelDrive:
                carController.SetState(new FourWheelDriveDrive(simpleDriftController));
                break;
            case CarState.FrontWheelDrive:
                carController.SetState(new FrontWheelDrive(simpleDriftController));
                break;
            case CarState.RearWheelDrive:
                carController.SetState(new RearWheelDrive(simpleDriftController));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}