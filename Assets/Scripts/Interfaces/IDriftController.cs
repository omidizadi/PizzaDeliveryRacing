using UnityEngine;

public interface IDriftController
{
    void DoDrift(WheelCollider wheelCollider, float drift);
}