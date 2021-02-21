using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftController : IDriftController
{
   
    public void DoDrift(WheelCollider wheelCollider, float drift)
    {
        var wheelFrictionCurve = wheelCollider.forwardFriction;
        wheelFrictionCurve.stiffness = 1 - (0.5f * drift);
        wheelCollider.forwardFriction = wheelFrictionCurve;
        var sidewaysFriction = wheelCollider.sidewaysFriction;
        sidewaysFriction.stiffness = 1 - (0.5f * drift);
        wheelCollider.sidewaysFriction = sidewaysFriction;
    }
}
