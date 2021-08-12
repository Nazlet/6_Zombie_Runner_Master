using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterSpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject harvestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnHarvester());
    }

    IEnumerator RepeatedlySpawnHarvester()
    {
        while (true) //forever
        {
            Instantiate(harvestPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
