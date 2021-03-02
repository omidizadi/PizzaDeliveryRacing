using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private ICarDriveState carDriveState;
    private IUserInput inputManager;
    private ICarLightController carLightController;


    [SerializeField] private CarModel carModel;
    [SerializeField] private Rigidbody carRigidBody;
    [SerializeField] private Transform carTransform;
    [SerializeField] private Transform centerOfMass;
    [SerializeField] private Transform[] wheelTransforms;
    [SerializeField] private WheelCollider[] wheelColliders;


    private Vector2 moveDirection;
    private float brakeValue;
    private float driftValue;
    private float wheelsRpm;
    private float engineRpm;
    private float enginePower;
    private int currentGear;

    private void Awake()
    {
        inputManager = GetComponent<IUserInput>();
        carLightController = GetComponent<ICarLightController>();
    }

    private void Start()
    {
        carRigidBody.centerOfMass = centerOfMass.localPosition;
    }

    private void OnEnable()
    {
        inputManager.OnMove += OnMove;
        inputManager.OnBrake += OnBrake;
        inputManager.OnDrift += OnDrift;
    }

    private void OnDisable()
    {
        inputManager.OnMove -= OnMove;
        inputManager.OnBrake -= OnBrake;
        inputManager.OnDrift -= OnDrift;
    }

    public void SetState(ICarDriveState driveState)
    {
        carDriveState = driveState;
    }

    private void OnMove(Vector2 value)
    {
        moveDirection = value;
    }

    private void OnBrake(float value)
    {
        brakeValue = value;
    }

    private void OnDrift(float value)
    {
        driftValue = value;
    }

    private void Update()
    {
        carLightController.BrakeLights(brakeValue > 0 || moveDirection.y < 0 || driftValue > 0);
    }

    private void FixedUpdate()
    {
        HandleRPM();
        HandleEngine();
        MoveVehicle();
        DriftVehicle();
        HandleBrake();
        HandleSteering();
        UpdateWheels();
        ApplyDownForce();
    }

    private void HandleRPM()
    {
        var rpmSum = 0f;
        var wheelsCount = 0;
        for (var i = 0; i < carModel.wheelsNumber; i++)
        {
            rpmSum += wheelColliders[i].rpm;
            wheelsCount++;
        }

        wheelsRpm = rpmSum / wheelsCount;
    }

    private void HandleEngine()
    {
        enginePower = carModel.engineTorque.Evaluate(engineRpm) * moveDirection.y;
        engineRpm = Mathf.Clamp(Mathf.Abs(wheelsRpm) * 3.6f, carModel.minRPM, carModel.maxRPM);
    }

    private void MoveVehicle()
    {
        carDriveState.MoveVehicle(wheelColliders, enginePower);
    }

    private void DriftVehicle()
    {
        carDriveState.DriftVehicle(wheelColliders, driftValue);
    }

    private void HandleSteering()
    {
        wheelColliders[0].steerAngle =
            moveDirection.x * Mathf.Rad2Deg * Mathf.Atan(2.55f / (carModel.steerRadius - (1.5f / 2)));
        wheelColliders[1].steerAngle =
            moveDirection.x * Mathf.Rad2Deg * Mathf.Atan(2.55f / (carModel.steerRadius + (1.5f / 2)));
    }

    private void HandleBrake()
    {
        carDriveState.HandleBrake(wheelColliders, carModel.brakeForce * brakeValue);
    }

    private void UpdateWheels()
    {
        for (var i = 0; i < carModel.wheelsNumber; i++)
        {
            wheelColliders[i].GetWorldPose(out var pos, out var rotation);
            wheelTransforms[i].position = pos;
            wheelTransforms[i].rotation = rotation;
        }
    }

    private void ApplyDownForce()
    {
        carRigidBody.AddForce(carRigidBody.velocity.magnitude * carModel.downForce * -carTransform.up);
    }
}