﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] GameObject torpedoLaunch;
    [SerializeField] GameObject torpedo;
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] Rigidbody shell;
    [SerializeField] GameObject gunBarrel;
    [SerializeField] float shellVelocity = 10f;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        ProcessFiring();
        ProcessTurretFiring();
        ApplyConstForce();
        ApplyMaxSpeed();
    }

    private void ApplyMaxSpeed()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void ApplyConstForce()
    {
        rb.AddForce(0,0,0);
    }

    private void ProcessFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(torpedo, torpedoLaunch.transform.position, torpedoLaunch.transform.rotation);
        }
    }
    private void ProcessTurretFiring()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Rigidbody shellInstance = Instantiate(shell, gunBarrel.transform.position, gunBarrel.transform.rotation) as Rigidbody;
            shellInstance.velocity = shellVelocity * gunBarrel.transform.forward;
        }
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.forward * mainThrust * Time.deltaTime);


    }


    //private void RotateLeft()
    //{
        //ApplyRotation(rotationThrust);

    //}

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);

    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.left * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}
