using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float obstacleThrust = 10f;
    [SerializeField] float secondsBetweenThrust = 2f;
    [SerializeField] float obstacleMaxSpeed = 1f;
    Rigidbody rb;
    bool inCoRoutine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(ObstacleRandomThrust());

        ApplyObstacleMaxSpeed();
    }

    IEnumerator ObstacleRandomThrust()
    {
        inCoRoutine = true;
        rb.AddRelativeForce(Random.onUnitSphere * obstacleThrust * Time.deltaTime);
        yield return new WaitForSeconds(secondsBetweenThrust);
        inCoRoutine = false;  
    }
    private void ApplyObstacleMaxSpeed()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, obstacleMaxSpeed);
    }
}
