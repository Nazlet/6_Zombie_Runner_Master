using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBergSpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject icebergPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnIceberg());
    }

    IEnumerator RepeatedlySpawnIceberg()
    {
        while (true) //forever
        {
            Instantiate(icebergPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
