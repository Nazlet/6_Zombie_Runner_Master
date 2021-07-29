using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour
{

    [SerializeField] float mainThrust = 100f;
    //[SerializeField] float rotationThrust = 1f;
    [SerializeField] float torpMaxSpeed = 100f;
    //[SerializeField] float rotationSpeed = 5f;
    //[SerializeField] float adjustmentx = 10f;
    //[SerializeField] float adjustmenty = 10f;
    //[SerializeField] float adjustmentz = 10f;


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
        //ProcessRotation();
        ApplyTorpMaxSpeed();
    }

    private void ApplyTorpMaxSpeed()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, torpMaxSpeed);
    }

    void ProcessThrust()
    {
        rb.AddRelativeForce(Vector3.forward * mainThrust * Time.deltaTime);
    }

    //void ProcessRotation()
    //{
    //    ApplyRotation(rotationThrust);
    //}

    //void ApplyRotation(float rotationThisFrame)
    //{
    //    rb.freezeRotation = true;  // freezing rotation so we can manually rotate
    //    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    //    rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(transform.position.x - adjustmentx, transform.position.y - adjustmenty, transform.position.z - adjustmentz));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    //    print("torpedo triggered");
    //}

}