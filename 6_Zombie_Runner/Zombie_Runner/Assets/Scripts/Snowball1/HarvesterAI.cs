using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HarvesterAI : MonoBehaviour
{
    [SerializeField] Transform collector;

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(collector.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
