using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Transform centerofmass;
    public WheelCollider wheelcolliderLeftFront;
    public WheelCollider wheelcolliderRightFront;
    public WheelCollider wheelcolliderLeftBack;
    public WheelCollider wheelcolliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;

    public float motortorque = 500f;
    public float maxsteer = 20f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerofmass.position;
    }

    private void FixedUpdate()
    {
        
        wheelcolliderLeftBack.motorTorque = Input.GetAxis("Vertical") * motortorque;
        wheelcolliderRightBack.motorTorque = Input.GetAxis("Vertical") * motortorque;
        wheelcolliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxsteer;
        wheelcolliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxsteer;
    }

    private void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelcolliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot;
       

        wheelcolliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightFront.position = pos;
        wheelRightFront.rotation = rot * Quaternion.Euler(0,180,0);

        wheelcolliderLeftBack.GetWorldPose(out pos, out rot);
        wheelLeftBack.position = pos;
        wheelLeftBack.rotation = rot;

        wheelcolliderRightBack.GetWorldPose(out pos, out rot);
        wheelRightBack.position = pos;
        wheelRightBack.rotation = rot * Quaternion.Euler(0, 180, 0);
    }
}
