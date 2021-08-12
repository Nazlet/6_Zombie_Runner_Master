using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float obstacleThrust = 10f;
    [SerializeField] float secondsBetweenThrust = 2f;
    [SerializeField] float secondsInActive = 10f;
    [SerializeField] float obstacleMaxSpeed = 1f;
    Rigidbody rb;
    bool inCoRoutine;
    bool inActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Apply on Trigger to contingent on tag.  Set bool. wait reset bool.
        ApplyObstacleMaxSpeed();

        if (!inCoRoutine && !inActive)
        {
            StartCoroutine(ObstacleRandomThrust());
        }    
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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                StartCoroutine(PauseRandomThrust());
                break;
        }
        
    }

    IEnumerator PauseRandomThrust()
    {
        inActive = true;
        StopCoroutine("ObstacleRandomThrust");
        print("iceberg impact");
        yield return new WaitForSeconds(secondsInActive);
        print("have waited");
        inActive = false;
        StartCoroutine("ObstacleRandomThrust");
    }
}
