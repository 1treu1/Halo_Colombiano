using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axle
{
    Front,
    Back
}

public struct Wheel
{
    public GameObject model;
    public WheelCollider wheelCollider;
    public Axle axle;
}

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField]
    private float maxAcceleration = 20f;
    [SerializeField]
    private float turnSensitive = 1.0f;
    [SerializeField]
    private float maxAngle = 45.0f;
    
    private float inputX, inputY;
    
    private Rigidbody _rb;

    public List<AxleInfo> axleInfos = new List<AxleInfo>();


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInputs();
        Move();
    }

    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        foreach (AxleInfo info in axleInfos)
        {
            if(info.isBack)
            {
                info.rigtWheel.motorTorque = inputY * maxAcceleration*500*Time.deltaTime;
                info.leftWheel.motorTorque = inputY * maxAcceleration*500*Time.deltaTime;
            }
            if(info.isFront)
            {
                var _steerAngle = inputX * turnSensitive * maxAngle;
                info.rigtWheel.steerAngle = Mathf.Lerp(info.rigtWheel.steerAngle,_steerAngle,0.5f);
                info.leftWheel.steerAngle = Mathf.Lerp(info.leftWheel.steerAngle,_steerAngle,0.5f);
            }

            AnimateWheels(info.rigtWheel,info.visualRightWheel);
            AnimateWheels(info.leftWheel,info.visualLeftWheel);
        }
    }

    private void AnimateWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Quaternion _rot;
        Vector3 _pos;

        Vector3 rotate = Vector3.zero;

        wheelCollider.GetWorldPose(out _pos, out _rot);
        wheelTransform.transform.rotation = _rot;
    }
}

[System.Serializable]
public class AxleInfo{
    public WheelCollider rigtWheel;
    public WheelCollider leftWheel;

    public Transform visualRightWheel;
    public Transform visualLeftWheel;

    public bool isBack;
    public bool isFront;
}