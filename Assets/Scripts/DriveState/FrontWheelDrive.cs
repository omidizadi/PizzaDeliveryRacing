using UnityEngine;

public class FrontWheelDrive : ICarDriveState
{
    private IDriftController driftController;

    public FrontWheelDrive(IDriftController driftController)
    {
        this.driftController = driftController;
    }
    public void HandleBrake(WheelCollider[] wheels, float brakeForce)
    {
        for (var i = 0; i < 2; i++)
        {
            wheels[i].brakeTorque = brakeForce;
        }
    }

    public void MoveVehicle(WheelCollider[] wheels, float enginePower)
    {
        for (var i = 0; i < 2; i++)
        {
            wheels[i].motorTorque = enginePower / 2;
        }
    }

    public void DriftVehicle(WheelCollider[] wheels, float drift)
    {
        for (var i = 0; i < 2; i++)
        {
            if (wheels[i].GetGroundHit(out var hit))
            {
                driftController.DoDrift(wheels[i], drift);
            }
        }
    }
}