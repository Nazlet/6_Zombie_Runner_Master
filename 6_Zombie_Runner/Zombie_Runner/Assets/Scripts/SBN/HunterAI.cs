using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAI : MonoBehaviour
{
    [SerializeField] Transform objectToRotate;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float huntermaxSpeed = 10f;


    float distanceToTarget = Mathf.Infinity;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            objectToRotate.LookAt(target);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void ApplyMaxSpeed()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, huntermaxSpeed);
    }
}
