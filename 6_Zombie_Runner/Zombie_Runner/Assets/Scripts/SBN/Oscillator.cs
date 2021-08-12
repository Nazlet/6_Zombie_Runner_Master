using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    [SerializeField] GameObject parentOsc;

    float movementFactor; // 0 for not moved, 1 for fully moved.
    Vector3 startingPos;

    void Start()
    {
        //startingPos = parentOsc.transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //protect against period is zero
        float cycles = Time.time / period; // grows continually from zero

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        startingPos = parentOsc.transform.position;
        transform.position = startingPos + offset;
    }
}
