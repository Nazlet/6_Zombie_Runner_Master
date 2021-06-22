using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(targetEnemy.position.x,objectToPan.localPosition.y,targetEnemy.position.z);
        objectToPan.LookAt(targetPosition);
    }
}
