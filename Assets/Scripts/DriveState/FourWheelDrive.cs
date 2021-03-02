using System;
using UnityEngine;

public class FourWheelDrive : ICarDriveState
{
    private IDriftController driftController;

    public FourWheelDrive(IDriftController driftController)
    {
        this.driftController = driftController;
    }

    public void HandleBrake(WheelCollider[] wheels, float brakeForce)
    {
        for (var i = 0; i < wheels.Length; i++)
        {
            wheels[i].brakeTorque = brakeForce;
        }
    }

    public void MoveVehicle(WheelCollider[] wheels, float enginePower)
    {
        for (var i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = enginePower / 4;
        }
    }

    public void DriftVehicle(WheelCollider[] wheels, float drift)
    {
        for (var i = 0; i < wheels.Length; i++)
        {
            driftController.DoDrift(wheels[i], drift);
        }
    }
}