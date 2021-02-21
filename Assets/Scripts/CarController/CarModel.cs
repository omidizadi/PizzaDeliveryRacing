using UnityEngine;

[CreateAssetMenu(fileName = "NewCarModel")]
public class CarModel : ScriptableObject
{
    public AnimationCurve engineTorque;
    public float minRPM;
    public float maxRPM;
    public float downForce;

    public int wheelsNumber;
    public float steerRadius;
    public float brakeForce;
}