using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    [SerializeField] float shellThrust = 100f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShellMomentum();
    }

    void ShellMomentum()
    {
        rb.AddRelativeForce(Vector3.up * shellThrust * Time.deltaTime);

    }
}
