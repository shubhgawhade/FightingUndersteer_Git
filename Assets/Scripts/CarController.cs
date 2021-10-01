using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 1000f;
    public float brakeForce = 3000f;
    public float brake;

    public bool rwd;
    public bool fwd;
    public bool awd;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        if (awd)
        {
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            rwd = false;
            fwd = false;
        }
        else if (rwd)
        {
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            fwd = false;
        }
        else if (fwd)
        {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            rwd = false;
        }
        
        if (isBreaking)
        {
            brake = brakeForce;
        }
        else
        {
            brake = 0;
        }
        frontLeftWheelCollider.brakeTorque = brake;
        frontRightWheelCollider.brakeTorque = brake;
        rearLeftWheelCollider.brakeTorque = brake;
        rearRightWheelCollider.brakeTorque = brake;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

}
