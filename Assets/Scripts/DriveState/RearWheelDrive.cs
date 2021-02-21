using UnityEngine;

public class RearWheelDrive : ICarDriveState
{
    
    private IDriftController driftController;

    public RearWheelDrive(IDriftController driftController)
    {
        this.driftController = driftController;
    }
    public void HandleBrake(WheelCollider[] wheels, float brakeForce)
    {
        for (var i = 2; i < wheels.Length; i++)
        {
            wheels[i].brakeTorque = brakeForce;
        }
    }

    public void MoveVehicle(WheelCollider[] wheels, float enginePower)
    {
        for (var i = 2; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = enginePower / 2;
        }
    }

    public void DriftVehicle(WheelCollider[] wheels, float drift)
    {
        for (var i = 2; i < wheels.Length; i++)
        {
            if (wheels[i].GetGroundHit(out var hit))
            {
                driftController.DoDrift(wheels[i], drift);
            }
        }
    }
}