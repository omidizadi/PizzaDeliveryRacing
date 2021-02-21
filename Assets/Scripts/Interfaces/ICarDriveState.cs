using UnityEngine;

public interface ICarDriveState
{
    void HandleBrake(WheelCollider[] wheels, float brakeForce);
    void MoveVehicle(WheelCollider[] wheels, float enginePower);
    void DriftVehicle(WheelCollider[] wheels, float drift);
}